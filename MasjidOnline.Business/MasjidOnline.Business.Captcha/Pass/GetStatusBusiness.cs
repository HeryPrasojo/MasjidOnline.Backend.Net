using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Pass;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Captcha.Pass;

public class GetStatusBusiness : IGetStatusBusiness
{
    public async Task<Response> GetAsync(IData _data, Session.Interface.Model.Session session)
    {
        if (!session.IsUserAnonymous) return new()
        {
            ResultCode = ResponseResultCode.CaptchaUnneed,
        };


        var any = await _data.Captcha.Pass.AnyAsync(session.Id);

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
