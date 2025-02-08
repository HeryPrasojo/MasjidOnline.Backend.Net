using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static async Task<Response> AnonymInfaqAsync(
        HttpContext httpContext,
        IAnonymInfaqBusiness anonymInfaqBusiness,
        ICaptchaData _captchaData,
        ISessionBusiness _sessionBusiness,
        ITransactionsData _transactionData,
        AnonymInfaqRequest anonymInfaqRequest)
    {
        return await anonymInfaqBusiness.InfaqAsync(_captchaData, _sessionBusiness, _transactionData, anonymInfaqRequest);
    }
}
