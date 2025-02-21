using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Captcha;
using MasjidOnline.Service.Captcha.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaQuestionBusiness(
    ICaptchaService _captchaService,
    ICaptchaIdGenerator _captchaIdGenerator) : ICaptchaQuestionBusiness
{
    public async Task<QuestionAddResponse> AddAsync(ICaptchaData _captchaData, ISessionBusiness _sessionBusiness)
    {
        if (_sessionBusiness.UserId != Constant.AnonymousUserId) return new()
        {
            ResultCode = ResponseResultCode.CaptchaPassed,
        };


        var existingCaptchaQuestion = await _captchaData.CaptchaQuestion.GetForAddAsync(_sessionBusiness.Id);

        if (existingCaptchaQuestion != default)
        {
            if (existingCaptchaQuestion.IsMatched) return new()
            {
                ResultCode = ResponseResultCode.CaptchaPassed,
            };


            var existingGenerateImageResult = _captchaService.GenerateImage(existingCaptchaQuestion.Degree);

            return new()
            {
                ResultCode = ResponseResultCode.Success,
                Stream = existingGenerateImageResult.Stream,
            };
        }


        var generateImageResult = _captchaService.GenerateRandomImage();

        var newCaptchaQuestion = new CaptchaQuestion
        {
            Id = _captchaIdGenerator.CaptchaQuestionId,
            DateTime = DateTime.UtcNow,
            Degree = generateImageResult.Degree,
            SessionId = _sessionBusiness.Id,
        };

        await _captchaData.CaptchaQuestion.AddAndSaveAsync(newCaptchaQuestion);


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Stream = generateImageResult.Stream,
        };
    }
}
