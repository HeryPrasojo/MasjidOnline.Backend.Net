using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaQuestionBusiness(
    ICaptchaService _captchaService,
    IDataAccess _dataAccess,
    IEntityIdGenerator _entityIdGenerator,
    IHash512Service _hash512Service) : ICaptchaQuestionBusiness
{
    public async Task<CreateResponse> CreateAsync(string? sessionId)
    {
        if (sessionId != default)
        {
            var existingCaptchaQuestion = await _dataAccess.CaptchaQuestionRepository.GetForCreateAsync(sessionId);

            if (existingCaptchaQuestion != default)
            {
                var captchaAnswer = await _dataAccess.CaptchaAnswerRepository.GetForCreateQuestionAsync(existingCaptchaQuestion.Id);

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
            }
        }


        if (sessionId == default)
        {
            sessionId = _hash512Service.HashRandom();
        }

        var generateImageResponse = _captchaService.GenerateRandomImage();


        var newCaptchaQuestion = new CaptchaQuestion
        {
            Id = _entityIdGenerator.CaptchaQuestionId,
            CreateDateTime = DateTime.UtcNow,
            Degree = generateImageResponse.Degree,
            SessionId = sessionId,
        };

        await _dataAccess.CaptchaQuestionRepository.AddAsync(newCaptchaQuestion);

        var changed = await _dataAccess.SaveAsync();

        if (changed != 1) return new()
        {
            ResultMessage = "Data save failed",
            ResultCode = ResponseResult.Error,
        };

        return new()
        {
            ResultCode = ResponseResult.Success,
            SessionId = sessionId,
            Stream = generateImageResponse.Stream,
        };
    }

    public async Task AnswerAsync(string sessionId)
    {
        if (sessionId == default) return;

        //_dataAccess
    }
}
