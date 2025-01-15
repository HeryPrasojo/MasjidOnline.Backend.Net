using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Api.Model.Exceptions;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Business.Captcha;

public class CaptchaAnswerBusiness(
    ICaptchaData _captchaData,
    ICaptchaIdGenerator _captchaIdGenerator) : ICaptchaAnswerBusiness
{
    public async Task<AnswerQuestionResponse> AnswerAsync(byte[]? sessionId, AnswerQuestionRequest answerQuestionRequest)
    {
        if (sessionId == default) throw new InputInvalidException(nameof(sessionId));

        if (answerQuestionRequest == default) throw new InputInvalidException(nameof(answerQuestionRequest));


        var captchaQuestion = await _captchaData.CaptchaQuestion.GetForAnswerAsync(sessionId);

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

        var changed = await _captchaData.CaptchaAnswer.AddAndSaveAsync(captchaAnswer);

        if (changed != 1) throw new ErrorException("Data save failed");


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
