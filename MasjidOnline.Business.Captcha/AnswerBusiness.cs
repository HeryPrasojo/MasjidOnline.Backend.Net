using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Captcha;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Captcha;

public class AnswerBusiness(
    ICaptchaIdGenerator _captchaIdGenerator,
    IFieldValidatorService _fieldValidatorService) : IAnswerBusiness
{
    public async Task<AnswerQuestionResponse> AnswerAsync(ICaptchaData _captchaData, byte[]? sessionId, AnswerQuestionRequest answerQuestionRequest)
    {
        _fieldValidatorService.ValidateRequired(sessionId); // todo change to text/string validation
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
