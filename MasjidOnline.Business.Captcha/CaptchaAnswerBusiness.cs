using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Captcha;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaAnswerBusiness(
    ICaptchaData _captchaData,
    ICaptchaIdGenerator _captchaIdGenerator,
    IFieldValidatorService _fieldValidatorService) : ICaptchaAnswerBusiness
{
    public async Task<AnswerQuestionResponse> AnswerAsync(byte[]? sessionId, AnswerQuestionRequest answerQuestionRequest)
    {
        _fieldValidatorService.ValidateRequired(sessionId);

        _fieldValidatorService.ValidateRequired(answerQuestionRequest);


        var captchaQuestion = await _captchaData.CaptchaQuestion.GetForAnswerAsync(sessionId!);

        if (captchaQuestion == default) throw new InputMismatchException($"{nameof(sessionId)}: {sessionId}");


        var degreeDiff = ((captchaQuestion.Degree + answerQuestionRequest.Degree) % 360f);
        var tolerance = 45f;

        var captchaAnswer = new CaptchaAnswer
        {
            Id = _captchaIdGenerator.CaptchaAnswerId,
            CaptchaQuestionId = captchaQuestion.Id,
            DateTime = DateTime.UtcNow,
            Degree = answerQuestionRequest.Degree,
            IsMatch = (degreeDiff < tolerance) && (degreeDiff > -tolerance),
        };

        await _captchaData.CaptchaAnswer.AddAndSaveAsync(captchaAnswer);


        if (!captchaAnswer.IsMatch)
        {
            return new()
            {
                ResultCode = ResponseResult.CaptchaWrong,
                ResultMessage = $"{nameof(answerQuestionRequest.Degree)}: {answerQuestionRequest.Degree}",
            };
        }

        return new()
        {
            ResultCode = ResponseResult.Success,
        };
    }
}
