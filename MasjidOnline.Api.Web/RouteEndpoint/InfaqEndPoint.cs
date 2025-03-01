using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Expired;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static async Task<Response> AddAnonymAsync(
        IAddAnonymBusiness _addAnonymBusiness,
        ICaptchaData _captchaData,
        ISessionBusiness _sessionBusiness,
        IInfaqsData _infaqsData,
        AddByAnonymRequest addByAnonymRequest)
    {
        return await _addAnonymBusiness.AddAsync(_captchaData, _sessionBusiness, _infaqsData, addByAnonymRequest);
    }

    internal static async Task<GetManyResponse<GetManyResponseRecord>> GetManyAsync(
        Business.Infaq.Interface.Infaq.IGetManyBusiness _getManyBusiness,
        IInfaqsData _infaqsData,
        GetManyRequest getManyRequest)
    {
        return await _getManyBusiness.GetAsync(_infaqsData, getManyRequest);
    }

    internal static async Task<GetManyResponse<GetManyDueResponseRecord>> GetManyDueAsync(
        IGetManyDueBusiness _getManyDueBusiness,
        IInfaqsData _infaqsData,
        GetManyDueRequest getManyDueRequest)
    {
        return await _getManyDueBusiness.GetAsync(_infaqsData, getManyDueRequest);
    }

    internal static async Task<GetOneResponse> GetOneAsync(
        IGetOneBusiness _getOneBusiness,
        IInfaqsData _infaqsData,
        GetOneRequest getOneRequest)
    {
        return await _getOneBusiness.GetAsync(_infaqsData, getOneRequest);
    }

    internal static async Task<GetOneDueResponse> GetOneDueAsync(
        IGetOneDueBusiness _getOneDueBusiness,
        IInfaqsData _infaqsData,
        GetOneDueRequest getOneDueRequest)
    {
        return await _getOneDueBusiness.GetAsync(_infaqsData, getOneDueRequest);
    }


    internal static async Task<Response> AddExpiredAsync(
        IAuthorizationBusiness _authorizationBusiness,
        IAddBusiness _addBusiness,
        IInfaqsData _infaqsData,
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        ExpiredAddRequest expiredAddRequest)
    {
        return await _addBusiness.AddAsync(_authorizationBusiness, _infaqsData, _sessionBusiness, _usersData, expiredAddRequest);
    }
}
