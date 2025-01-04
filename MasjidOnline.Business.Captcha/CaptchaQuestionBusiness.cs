using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Core;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaQuestionBusiness(
    ICaptchaService _captchaService,
    ICoreData _dataAccess,
    IEntityIdGenerator _entityIdGenerator,
    IHash512Service _hash512Service) : ICaptchaQuestionBusiness
{
    // todo validate user session exists (captcha not needed)
    public async Task<CreateQuestionResponse> CreateAsync(string? anonymousSessionId)
    {
        if (anonymousSessionId != default)
        {
            var existingCaptchaQuestion = await _dataAccess.CaptchaQuestionRepository.GetForCreateAsync(anonymousSessionId);

            if (existingCaptchaQuestion != default)
            {
                var captchaAnswer = await _dataAccess.CaptchaAnswerRepository.GetForCreateQuestionAsync(existingCaptchaQuestion.Id);

                if (captchaAnswer == default)
                {
                    var existingGenerateImageResponse = _captchaService.GenerateImage(existingCaptchaQuestion.Degree);

                    return new()
                    {
                        ResultCode = ResponseResult.Success,
                        SessionId = anonymousSessionId,
                        Stream = existingGenerateImageResponse.Stream,
                    };
                }

                if (captchaAnswer.IsMatch)
                {
                    return new()
                    {
                        ResultCode = ResponseResult.CaptchaPassed,
                    };
                }
            }
        }


        if (anonymousSessionId == default)
        {
            anonymousSessionId = _hash512Service.HashRandom();
        }

        var generateImageResponse = _captchaService.GenerateRandomImage();


        var newCaptchaQuestion = new CaptchaQuestion
        {
            Id = _entityIdGenerator.CaptchaQuestionId,
            CreateDateTime = DateTime.UtcNow,
            Degree = generateImageResponse.Degree,
            SessionId = anonymousSessionId,
        };

        await _dataAccess.CaptchaQuestionRepository.AddAsync(newCaptchaQuestion);

        var changed = await _dataAccess.SaveAsync();

        if (changed != 1) return new()
        {
            ResultCode = ResponseResult.Error,
            ResultMessage = "Data save failed",
        };

        return new()
        {
            ResultCode = ResponseResult.Success,
            SessionId = anonymousSessionId,
            Stream = generateImageResponse.Stream,
        };
    }
}
