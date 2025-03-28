using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Captcha;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Captcha.Captcha;

public class CaptchaUpdateBusiness(
    ICaptchaService _captchaService,
    ICaptchaIdGenerator _captchaIdGenerator,
    IFieldValidatorService _fieldValidatorService) : ICaptchaUpdateBusiness
{
    public async Task<CaptchaUpdateResponse> UpdateAsync(IData _data, ISessionBusiness _sessionBusiness, CaptchaUpdateRequest captchaUpdateRequest)
    {
        _fieldValidatorService.ValidateRequired(captchaUpdateRequest);


        var captcha = await _data.Captcha.Captcha.GetForUpdateAsync(_sessionBusiness.Id);

        if (captcha == default) throw new InputMismatchException($"{nameof(_sessionBusiness.Id)}: {_sessionBusiness.Id}");

        if (captcha.IsMatched == true) return new()
        {
            ResultCode = ResponseResultCode.CaptchaPass,
        };

        var utcNow = DateTime.UtcNow;

        if (captcha.IsMatched == false)
        {
            //var generateImageResult = _captchaService.GenerateRandomImage();

            var newCaptcha = new Entity.Captcha.Captcha
            {
                Id = _captchaIdGenerator.CaptchaId,
                DateTime = utcNow,
                //QuestionFloat = generateImageResult.Degree,
                SessionId = _sessionBusiness.Id,
            };

            await _data.Captcha.Captcha.AddAndSaveAsync(newCaptcha);

            return new()
            {
                ResultCode = ResponseResultCode.CaptchaUnpass,
                //Stream = generateImageResult.Stream,
            };
        }


        var degreeDiff = (captcha.QuestionFloat + captchaUpdateRequest.AnswerFloat) % 360f;
        var tolerance = 45f;
        var isMatch = (degreeDiff < tolerance) && (degreeDiff > -tolerance);

        _data.Captcha.Captcha.SetAnswer(captcha.Id, captchaUpdateRequest.AnswerFloat, isMatch, utcNow);


        if (!isMatch)
        {
            //var generateImageResult = _captchaService.GenerateRandomImage();

            var newCaptcha = new Entity.Captcha.Captcha
            {
                Id = _captchaIdGenerator.CaptchaId,
                DateTime = utcNow,
                //QuestionFloat = generateImageResult.Degree,
                SessionId = _sessionBusiness.Id,
            };

            await _data.Captcha.Captcha.AddAndSaveAsync(newCaptcha);

            return new()
            {
                ResultCode = ResponseResultCode.CaptchaWrong,
                //Stream = generateImageResult.Stream,
            };
        }


        await _data.Captcha.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
