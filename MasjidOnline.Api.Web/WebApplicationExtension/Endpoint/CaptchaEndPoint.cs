using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class CaptchaEndpoint
{
    internal static class Pass
    {
        internal static async Task<Response> GetStatusAsync(
            IBusiness _business,
            IData _data,
            Session _sessionBusiness)
        {
            return await _business.Captcha.Pass.GetStatus.GetAsync(_data, _sessionBusiness);
        }
    }
}
