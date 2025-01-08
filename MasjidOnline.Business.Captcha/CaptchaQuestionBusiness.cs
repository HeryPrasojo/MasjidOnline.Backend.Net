﻿using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Entity.Captcha;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaQuestionBusiness(
    ICaptchaService _captchaService,
    ICaptchaData _captchaData,
    ICaptchaEntityIdGenerator _captchaEntityIdGenerator,
    IHash512Service _hash512Service) : ICaptchaQuestionBusiness
{
    // todo validate user session exists (captcha not needed)
    public async Task<CreateQuestionResponse> CreateAsync(string? sessionId)
    {
        if (sessionId != default)
        {
            var existingCaptchaQuestion = await _captchaData.CaptchaQuestion.GetForCreateAsync(sessionId);

            if (existingCaptchaQuestion != default)
            {
                var captchaAnswer = await _captchaData.CaptchaAnswer.GetForCreateQuestionAsync(existingCaptchaQuestion.Id);

                if (captchaAnswer == default)
                {
                    var existingGenerateImageResponse = _captchaService.GenerateImage(existingCaptchaQuestion.Degree);

                    return new()
                    {
                        ResultCode = ResponseResult.Success,
                        SessionId = sessionId,
                        Stream = existingGenerateImageResponse.Stream,
                    };
                }

                if (captchaAnswer.IsMatch) return new()
                {
                    ResultCode = ResponseResult.CaptchaPassed,
                };
            }
        }


        if (sessionId == default)
        {
            sessionId = _hash512Service.HashRandom();
        }

        var generateImageResponse = _captchaService.GenerateRandomImage();


        var newCaptchaQuestion = new CaptchaQuestion
        {
            Id = _captchaEntityIdGenerator.CaptchaQuestionId,
            CreateDateTime = DateTime.UtcNow,
            Degree = generateImageResponse.Degree,
            SessionId = sessionId,
        };

        await _captchaData.CaptchaQuestion.AddAsync(newCaptchaQuestion);

        var changed = await _captchaData.SaveAsync();

        if (changed != 1) return new() { ResultCode = ResponseResult.Error, ResultMessage = "Data save failed", };

        return new()
        {
            ResultCode = ResponseResult.Success,
            SessionId = sessionId,
            Stream = generateImageResponse.Stream,
        };
    }
}
