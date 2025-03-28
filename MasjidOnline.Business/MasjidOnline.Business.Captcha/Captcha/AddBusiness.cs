using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Captcha;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Captcha.Interface;

namespace MasjidOnline.Business.Captcha.Captcha;

public class AddBusiness(
    ICaptchaService _captchaService,
    ICaptchaIdGenerator _captchaIdGenerator) : IAddBusiness
{
    public async Task<CaptchaAddResponse> AddAsync(IData _data, ISessionBusiness _sessionBusiness)
    {
        if (_sessionBusiness.UserId != Constant.UserId.Anonymous) return new()
        {
            ResultCode = ResponseResultCode.CaptchaPass,
        };


        var existingCaptcha = await _data.Captcha.Captcha.GetForAddAsync(_sessionBusiness.Id);

        if (existingCaptcha != default)
        {
            if (existingCaptcha.IsMatched == true) return new()
            {
                ResultCode = ResponseResultCode.CaptchaPass,
            };

            if (existingCaptcha.IsMatched == default)
            {
                //var existingGenerateImageResult = _captchaService.GenerateImage(existingCaptcha.QuestionFloat);

                return new()
                {
                    ResultCode = ResponseResultCode.Success,
                    //Stream = existingGenerateImageResult.Stream,
                };
            }
        }


        //var generateImageResult = _captchaService.GenerateRandomImage();

        var newCaptcha = new Entity.Captcha.Captcha
        {
            Id = _captchaIdGenerator.CaptchaId,
            DateTime = DateTime.UtcNow,
            //QuestionFloat = generateImageResult.Degree,
            SessionId = _sessionBusiness.Id,
        };

        await _data.Captcha.Captcha.AddAndSaveAsync(newCaptcha);


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            //Stream = generateImageResult.Stream,
        };
    }
}
