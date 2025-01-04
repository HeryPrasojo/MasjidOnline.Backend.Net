﻿using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity;

namespace MasjidOnline.Business.Captcha;

public class CaptchaAnswerBusiness(
    IDataAccess _dataAccess,
    IEntityIdGenerator _entityIdGenerator) : ICaptchaAnswerBusiness
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


        var captchaQuestion = await _dataAccess.CaptchaQuestionRepository.GetForAnswerAsync(anonymousSessionId);

        if (captchaQuestion == default) return new()
        {
            ResultCode = ResponseResult.InputNotMatch,
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

        await _dataAccess.CaptchaAnswerRepository.AddAsync(captchaAnswer);



        if (!captchaAnswer.IsMatch)
        {
            return new()
            {
                ResultCode = ResponseResult.InputNotMatch,
                ResultMessage = $"{nameof(answerQuestionRequest.Degree)}: {answerQuestionRequest.Degree}",
            };
        }


        //_dataAccess
    }
}