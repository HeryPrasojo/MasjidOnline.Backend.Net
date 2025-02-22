using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static async Task<Response> AddByAnonymAsync(
        IInfaqAddBusiness _infaqAddBusiness,
        ICaptchaData _captchaData,
        ISessionBusiness _sessionBusiness,
        IInfaqsData _infaqsData,
        AddByAnonymRequest addByAnonymRequest)
    {
        return await _infaqAddBusiness.AddByAnonymAsync(_captchaData, _sessionBusiness, _infaqsData, addByAnonymRequest);
    }

    internal static async Task<GetManyResponse<GetManyResponseRecord>> GetManyAsync(
        IInfaqGetBusiness _infaqGetBusiness,
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        IInfaqsData _infaqsData,
        GetManyRequest getManyRequest)
    {
        return await _infaqGetBusiness.GetManyAsync(_sessionBusiness, _usersData, _infaqsData, getManyRequest);
    }
}
