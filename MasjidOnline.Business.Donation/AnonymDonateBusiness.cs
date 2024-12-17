using MasjidOnline.Api.Model.Donation;
using MasjidOnline.Business.Donation.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Business.Donation;

public class AnonymDonateBusiness(
    ICaptchaService _captchaService,
    IDataAccess _dataAccess,
    IHash512Service _hash512Service) : IAnonymDonateBusiness
{
    public void Donate(string sessionId, DonateRequest donateRequest)
    {
        if (sessionId == default)
        {
            sessionId = _hash512Service.HashRandom();
        }

        var generateImageResponse = _captchaService.GenerateImage();


        // todo
    }
}
