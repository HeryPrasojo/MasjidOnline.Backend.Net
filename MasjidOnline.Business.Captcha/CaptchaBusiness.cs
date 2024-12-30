using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaBusiness(
    ICaptchaService _captchaService,
    IDataAccess _dataAccess,
    IHash512Service _hash512Service) : ICaptchaBusiness
{
    public async Task<CreateResponse> CreateAsync(string? sessionId)
    {
        if (sessionId == default)
        {
            sessionId = _hash512Service.HashRandom();
        }

        var generateImageResponse = _captchaService.GenerateImage();


        var captchaQuestion = new CaptchaQuestion
        {
            CreateDateTime = DateTime.UtcNow,
            Degree = generateImageResponse.Degree,
            SessionId = sessionId,
        };

        await _dataAccess.CaptchaQuestionRepository.AddAsync(captchaQuestion);

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
