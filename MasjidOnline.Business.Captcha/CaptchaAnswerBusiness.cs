﻿using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Business.Captcha;

public class CaptchaAnswerBusiness(
    ICoreData _coreData,
    ICoreEntityIdGenerator _entityIdGenerator) : ICaptchaAnswerBusiness
{
    public async Task<AnswerQuestionResponse> AnswerAsync(string anonymousSessionId, AnswerQuestionRequest answerQuestionRequest)
    {
        if (anonymousSessionId == default) return new()
        {
            ResultCode = ResponseResult.InputInvalid,
            ResultMessage = $"{nameof(anonymousSessionId)} required",
        };

        if (answerQuestionRequest == default) return new()
        {
            ResultCode = ResponseResult.InputInvalid,
            ResultMessage = $"{nameof(answerQuestionRequest)} required",
        };


        var captchaQuestion = await _coreData.CaptchaQuestion.GetForAnswerAsync(anonymousSessionId);

        if (captchaQuestion == default) return new()
        {
            ResultCode = ResponseResult.InputMismatch,
            ResultMessage = $"{nameof(anonymousSessionId)}: {anonymousSessionId}",
        };


        var captchaAnswer = new CaptchaAnswer
        {
            Id = _entityIdGenerator.CaptchaAnswerId,
            CaptchaQuestionId = captchaQuestion.Id,
            CreateDateTime = DateTime.UtcNow,
            Degree = captchaQuestion.Degree,
            IsMatch = captchaQuestion.Degree == answerQuestionRequest.Degree,
        };

        await _coreData.CaptchaAnswer.AddAsync(captchaAnswer);



        if (!captchaAnswer.IsMatch)
        {
            return new()
            {
                ResultCode = ResponseResult.InputMismatch,
                ResultMessage = $"{nameof(answerQuestionRequest.Degree)}: {answerQuestionRequest.Degree}",
            };
        }

        // todo
        throw new Exception("todo");
        //_dataAccess
    }
}
