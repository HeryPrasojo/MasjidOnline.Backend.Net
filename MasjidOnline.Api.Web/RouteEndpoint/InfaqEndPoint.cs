using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static async Task<Response> AnonymInfaqAsync(
        IAnonymInfaqBusiness _anonymInfaqBusiness,
        ICaptchaData _captchaData,
        ISessionBusiness _sessionBusiness,
        IInfaqsData _infaqsData,
        AnonymInfaqRequest anonymInfaqRequest)
    {
        return await _anonymInfaqBusiness.InfaqAsync(_captchaData, _sessionBusiness, _infaqsData, anonymInfaqRequest);
    }

    internal static async Task<IEnumerable<TabularQueryResponse>> QueryAsync(
        ITabularBusiness _tabularBusiness,
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        IInfaqsData _infaqsData,
        TabularQueryRequest queryRequest)
    {
        return await _tabularBusiness.QueryAsync(_sessionBusiness, _usersData, _infaqsData, queryRequest);
    }
}
