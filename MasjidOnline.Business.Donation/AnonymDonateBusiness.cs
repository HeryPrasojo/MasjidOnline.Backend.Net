using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Model.Donation;
using MasjidOnline.Business.Donation.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Business.Donation;

public class AnonymDonateBusiness(
    ICaptchaService _captchaService,
    IDataAccess _dataAccess,
    IHash512Service _hash512Service) : IAnonymDonateBusiness
{
    public async Task<AnonymDonateResponse> DonateAsync(string? sessionId)
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
            Message = "Data save failed",
            Result = ResponseResult.Error,
        };

        return new()
        {
            Result = ResponseResult.Success,
            SessionId = sessionId,
        };
        // todo
    }
}
