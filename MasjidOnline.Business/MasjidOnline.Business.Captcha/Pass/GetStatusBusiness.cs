using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Pass;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Captcha.Pass;

public class GetStatusBusiness : IGetStatusBusiness
{
    public async Task<Response> GetAsync(IData _data, ISessionBusiness _sessionBusiness)
    {
        if (!_sessionBusiness.IsUserAnonymous) return new()
        {
            ResultCode = ResponseResultCode.CaptchaUnneed,
        };


        var any = await _data.Captcha.Pass.AnyAsync(_sessionBusiness.Id);

        if (any) return new()
        {
            ResultCode = ResponseResultCode.CaptchaPass,
        };


        return new()
        {
            ResultCode = ResponseResultCode.CaptchaUnpass,
        };
    }
}
