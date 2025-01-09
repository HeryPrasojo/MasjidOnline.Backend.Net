using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Business.Captcha;

public class CaptchaAnswerBusiness(
    ICaptchaData _captchaData,
    ICaptchaEntityIdGenerator _captchaEntityIdGenerator) : ICaptchaAnswerBusiness
{
    public async Task<AnswerQuestionResponse> AnswerAsync(byte[] sessionId, AnswerQuestionRequest answerQuestionRequest)
    {
        // todo switch return to exception
        if (sessionId == default) return new()
        {
            ResultCode = ResponseResult.InputInvalid,
            ResultMessage = $"{nameof(sessionId)} required",
        };

        if (answerQuestionRequest == default) return new()
        {
            ResultCode = ResponseResult.InputInvalid,
            ResultMessage = $"{nameof(answerQuestionRequest)} required",
        };


        var captchaQuestion = await _captchaData.CaptchaQuestion.GetForAnswerAsync(sessionId);

        if (captchaQuestion == default) return new()
        {
            ResultCode = ResponseResult.InputMismatch,
            ResultMessage = $"{nameof(sessionId)}: {sessionId}",
        };


        var captchaAnswer = new CaptchaAnswer
        {
            Id = _captchaEntityIdGenerator.CaptchaAnswerId,
            CaptchaQuestionId = captchaQuestion.Id,
            CreateDateTime = DateTime.UtcNow,
            Degree = captchaQuestion.Degree,
            IsMatch = captchaQuestion.Degree == answerQuestionRequest.Degree,
        };

        await _captchaData.CaptchaAnswer.AddAsync(captchaAnswer);



        if (!captchaAnswer.IsMatch)
        {
            return new()
            {
                ResultCode = ResponseResult.InputMismatch,
                ResultMessage = $"{nameof(answerQuestionRequest.Degree)}: {answerQuestionRequest.Degree}",
            };
        }

        return new()
        {
            ResultCode = ResponseResult.Success,
        };
    }
}
