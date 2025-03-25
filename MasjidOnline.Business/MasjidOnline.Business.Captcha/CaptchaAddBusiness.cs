using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Captcha.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaAddBusiness(
    ICaptchaService _captchaService,
    ICaptchaIdGenerator _captchaIdGenerator) : ICaptchaAddBusiness
{
    public async Task<CaptchaAddResponse> AddAsync(ICaptchaDatabase _captchaDatabase, ISessionBusiness _sessionBusiness)
    {
        if (_sessionBusiness.UserId != Constant.UserId.Anonymous) return new()
        {
            ResultCode = ResponseResultCode.CaptchaPass,
        };


        var existingCaptcha = await _captchaDatabase.Captcha.GetForAddAsync(_sessionBusiness.Id);

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

        await _captchaDatabase.Captcha.AddAndSaveAsync(newCaptcha);


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            //Stream = generateImageResult.Stream,
        };
    }
}
