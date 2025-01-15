using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Api.Model.Exceptions;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Entity.Captcha;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaQuestionBusiness(
    ICaptchaService _captchaService,
    ICaptchaData _captchaData,
    ICaptchaIdGenerator _captchaIdGenerator,
    IHash512Service _hash512Service) : ICaptchaQuestionBusiness
{
    // todo validate user session exists (captcha not needed)
    public async Task<CreateQuestionResponse> CreateAsync(byte[]? sessionId)
    {
        if (sessionId != default)
        {
            var existingCaptchaQuestion = await _captchaData.CaptchaQuestion.GetForCreateAsync(sessionId);

            if (existingCaptchaQuestion != default)
            {
                var isMatch = await _captchaData.CaptchaAnswer.GetIsMatchByCaptchaQuestionIdAsync(existingCaptchaQuestion.Id);

                if (isMatch == default)
                {
                    var existingGenerateImageResponse = _captchaService.GenerateImage(existingCaptchaQuestion.Degree);

                    return new()
                    {
                        ResultCode = ResponseResult.Success,
                        SessionId = sessionId,
                        Stream = existingGenerateImageResponse.Stream,
                    };
                }

                if (isMatch == true) return new()
                {
                    ResultCode = ResponseResult.CaptchaPassed,
                };
            }
        }


        if (sessionId == default)
        {
            sessionId = _hash512Service.RandomDigestBytes;
        }

        var generateImageResponse = _captchaService.GenerateRandomImage();


        var newCaptchaQuestion = new CaptchaQuestion
        {
            Id = _captchaIdGenerator.CaptchaQuestionId,
            DateTime = DateTime.UtcNow,
            Degree = generateImageResponse.Degree,
            SessionId = sessionId,
        };

        var changed = await _captchaData.CaptchaQuestion.AddAndSaveAsync(newCaptchaQuestion);

        if (changed != 1) throw new ErrorException("Data save failed");

        return new()
        {
            ResultCode = ResponseResult.Success,
            SessionId = sessionId,
            Stream = generateImageResponse.Stream,
        };
    }
}
