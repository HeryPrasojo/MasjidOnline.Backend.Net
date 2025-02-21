using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Captcha;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaAnswerBusiness(
    ICaptchaIdGenerator _captchaIdGenerator,
    IFieldValidatorService _fieldValidatorService) : ICaptchaAnswerBusiness
{
    public async Task<Response> AddAsync(ICaptchaData _captchaData, ISessionBusiness _sessionBusiness, AnswerAddRequest answerAddRequest)
    {
        _fieldValidatorService.ValidateRequired(answerAddRequest);


        var captchaQuestion = await _captchaData.CaptchaQuestion.GetForAnswerAddAsync(_sessionBusiness.Id);

        if (captchaQuestion == default) throw new InputMismatchException($"{nameof(_sessionBusiness.Id)}: {_sessionBusiness.Id}");


        var degreeDiff = ((captchaQuestion.Degree + answerAddRequest.Degree) % 360f);
        var tolerance = 45f;

        var captchaAnswer = new CaptchaAnswer
        {
            Id = _captchaIdGenerator.CaptchaAnswerId,
            CaptchaQuestionId = captchaQuestion.Id,
            DateTime = DateTime.UtcNow,
            Degree = answerAddRequest.Degree,
            IsMatch = (degreeDiff < tolerance) && (degreeDiff > -tolerance),
        };

        await _captchaData.CaptchaAnswer.AddAndSaveAsync(captchaAnswer);


        if (!captchaAnswer.IsMatch)
        {
            return new()
            {
                ResultCode = ResponseResultCode.CaptchaWrong,
                ResultMessage = $"{nameof(answerAddRequest.Degree)}: {answerAddRequest.Degree}",
            };
        }

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
