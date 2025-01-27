using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static async Task<AnonymInfaqResponse> AnonymInfaqAsync(
        HttpContext httpContext,
        IAnonymInfaqBusiness anonymInfaqBusiness,
        ICaptchaData _captchaData,
        ITransactionData _transactionData,
        AnonymInfaqRequest anonymInfaqRequest)
    {
        var sessionIdBase64 = httpContext.Request.Cookies[Constant.HttpCookieSessionName];

        var sessionId = sessionIdBase64 == default ? default : Convert.FromBase64String(sessionIdBase64!);

        var anonymInfaqResponse = await anonymInfaqBusiness.InfaqAsync(_captchaData, _transactionData, sessionId, anonymInfaqRequest);

        return anonymInfaqResponse;
    }
}
