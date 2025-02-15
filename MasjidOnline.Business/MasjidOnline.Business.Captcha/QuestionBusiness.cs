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

public class QuestionBusiness(
    ICaptchaService _captchaService,
    ICaptchaIdGenerator _captchaIdGenerator) : IQuestionBusiness
{
    public async Task<CreateQuestionResponse> CreateAsync(ICaptchaData _captchaData, ISessionBusiness _sessionBusiness)
    {
        if (_sessionBusiness.UserId != Constant.AnonymousUserId) return new()
        {
            ResultCode = ResponseResult.CaptchaPassed,
        };


        var existingCaptchaQuestion = await _captchaData.CaptchaQuestion.GetForCreateAsync(_sessionBusiness.Id);

        if (existingCaptchaQuestion != default)
        {
            if (existingCaptchaQuestion.IsMatched) return new()
            {
                ResultCode = ResponseResult.CaptchaPassed,
            };


            var existingImage = _captchaService.GenerateImage(existingCaptchaQuestion.Degree);

            return new()
            {
                ResultCode = ResponseResult.Success,
                Stream = existingImage.Stream,
            };
        }


        var generateImageResponse = _captchaService.GenerateRandomImage();

        var newCaptchaQuestion = new CaptchaQuestion
        {
            Id = _captchaIdGenerator.CaptchaQuestionId,
            DateTime = DateTime.UtcNow,
            Degree = generateImageResponse.Degree,
            SessionId = _sessionBusiness.Id,
        };

        await _captchaData.CaptchaQuestion.AddAndSaveAsync(newCaptchaQuestion);


        return new()
        {
            ResultCode = ResponseResult.Success,
            Stream = generateImageResponse.Stream,
        };
    }
}
