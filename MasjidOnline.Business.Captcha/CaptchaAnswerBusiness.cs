using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Api.Model.Exception;
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
            CreateDateTime = DateTime.UtcNow,
            Degree = answerQuestionRequest.Degree,
            IsMatch = (degreeDiff < tolerance) && (degreeDiff > -tolerance),
        };

        await _captchaData.CaptchaAnswer.AddAsync(captchaAnswer);

        await _captchaData.SaveAsync();



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
