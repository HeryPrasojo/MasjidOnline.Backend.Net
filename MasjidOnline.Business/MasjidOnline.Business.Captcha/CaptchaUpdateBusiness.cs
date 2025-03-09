using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaUpdateBusiness(
    ICaptchaService _captchaService,
    ICaptchaIdGenerator _captchaIdGenerator,
    IFieldValidatorService _fieldValidatorService) : ICaptchaUpdateBusiness
{
    public async Task<CaptchaUpdateResponse> UpdateAsync(ICaptchaData _captchaData, ISessionBusiness _sessionBusiness, CaptchaUpdateRequest captchaUpdateRequest)
    {
        _fieldValidatorService.ValidateRequired(captchaUpdateRequest);


        var captcha = await _captchaData.Captcha.GetForUpdateAsync(_sessionBusiness.Id);

        if (captcha == default) throw new InputMismatchException($"{nameof(_sessionBusiness.Id)}: {_sessionBusiness.Id}");

        if (captcha.IsMatched == true) return new()
        {
            ResultCode = ResponseResultCode.CaptchaPass,
        };

        var utcNow = DateTime.UtcNow;

        if (captcha.IsMatched == false)
        {
            var generateImageResult = _captchaService.GenerateRandomImage();

            var newCaptcha = new Entity.Captcha.Captcha
            {
                Id = _captchaIdGenerator.CaptchaId,
                DateTime = utcNow,
                QuestionFloat = generateImageResult.Degree,
                SessionId = _sessionBusiness.Id,
            };

            await _captchaData.Captcha.AddAndSaveAsync(newCaptcha);

            return new()
            {
                ResultCode = ResponseResultCode.CaptchaUnpass,
                Stream = generateImageResult.Stream,
            };
        }


        var degreeDiff = (captcha.QuestionFloat + captchaUpdateRequest.AnswerFloat) % 360f;
        var tolerance = 45f;
        var isMatch = (degreeDiff < tolerance) && (degreeDiff > -tolerance);

        _captchaData.Captcha.SetAnswer(captcha.Id, captchaUpdateRequest.AnswerFloat, isMatch, utcNow);


        if (!isMatch)
        {
            var generateImageResult = _captchaService.GenerateRandomImage();

            var newCaptcha = new Entity.Captcha.Captcha
            {
                Id = _captchaIdGenerator.CaptchaId,
                DateTime = utcNow,
                QuestionFloat = generateImageResult.Degree,
                SessionId = _sessionBusiness.Id,
            };

            await _captchaData.Captcha.AddAndSaveAsync(newCaptcha);

            return new()
            {
                ResultCode = ResponseResultCode.CaptchaWrong,
                Stream = generateImageResult.Stream,
            };
        }


        await _captchaData.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
