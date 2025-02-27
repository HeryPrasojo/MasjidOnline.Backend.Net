using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static async Task<Response> AddAnonymAsync(
        IInfaqAddAnonymBusiness _infaqAddAnonymBusiness,
        ICaptchaData _captchaData,
        ISessionBusiness _sessionBusiness,
        IInfaqsData _infaqsData,
        AddByAnonymRequest addByAnonymRequest)
    {
        return await _infaqAddAnonymBusiness.AddAsync(_captchaData, _sessionBusiness, _infaqsData, addByAnonymRequest);
    }

    internal static async Task<GetManyResponse<GetManyResponseRecord>> GetManyAsync(
        IInfaqGetManyBusiness _infaqGetManyBusiness,
        IInfaqsData _infaqsData,
        GetManyRequest getManyRequest)
    {
        return await _infaqGetManyBusiness.GetAsync(_infaqsData, getManyRequest);
    }

    internal static async Task<GetOneResponse> GetOneAsync(
        IInfaqGetOneBusiness _infaqGetOneBusiness,
        IInfaqsData _infaqsData,
        GetOneRequest getOneRequest)
    {
        return await _infaqGetOneBusiness.GetAsync(_infaqsData, getOneRequest);
    }


    internal static async Task<Response> AddExpiredAsync(
        IAuthorizationBusiness _authorizationBusiness,
        IExpiredAddBusiness _expiredAddBusiness,
        IInfaqsData _infaqsData,
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        ExpiredAddRequest expiredAddRequest)
    {
        return await _expiredAddBusiness.AddAsync(_authorizationBusiness, _infaqsData, _sessionBusiness, _usersData, expiredAddRequest);
    }
}
