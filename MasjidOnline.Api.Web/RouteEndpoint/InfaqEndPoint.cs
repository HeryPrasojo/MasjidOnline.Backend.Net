using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static class Infaq
    {
        internal static async Task<Response> AddAnonymAsync(
            Business.Infaq.Interface.Infaq.IAddAnonymBusiness _addAnonymBusiness,
            ICaptchaData _captchaData,
            ISessionBusiness _sessionBusiness,
            IInfaqsData _infaqsData,
            Business.Infaq.Interface.Model.Infaq.AddByAnonymRequest addByAnonymRequest)
        {
            return await _addAnonymBusiness.AddAsync(_captchaData, _sessionBusiness, _infaqsData, addByAnonymRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Infaq.GetManyResponseRecord>> GetManyAsync(
            Business.Infaq.Interface.Infaq.IGetManyBusiness _getManyBusiness,
            IInfaqsData _infaqsData,
            Business.Infaq.Interface.Model.Infaq.GetManyRequest getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_infaqsData, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Infaq.GetManyDueResponseRecord>> GetManyDueAsync(
            Business.Infaq.Interface.Infaq.IGetManyDueBusiness _getManyDueBusiness,
            IInfaqsData _infaqsData,
            Business.Infaq.Interface.Model.Infaq.GetManyDueRequest getManyDueRequest)
        {
            return await _getManyDueBusiness.GetAsync(_infaqsData, getManyDueRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Infaq.GetOneResponse> GetOneAsync(
            Business.Infaq.Interface.Infaq.IGetOneBusiness _getOneBusiness,
            IInfaqsData _infaqsData,
            Business.Infaq.Interface.Model.Infaq.GetOneRequest getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_infaqsData, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Infaq.GetOneDueResponse> GetOneDueAsync(
            Business.Infaq.Interface.Infaq.IGetOneDueBusiness _getOneDueBusiness,
            IInfaqsData _infaqsData,
            Business.Infaq.Interface.Model.Infaq.GetOneDueRequest getOneDueRequest)
        {
            return await _getOneDueBusiness.GetAsync(_infaqsData, getOneDueRequest);
        }
    }

    internal static class Expired
    {
        internal static async Task<Response> AddExpiredAsync(
            IAuthorizationBusiness _authorizationBusiness,
            Business.Infaq.Interface.Expired.IAddBusiness _addBusiness,
            IInfaqsData _infaqsData,
            ISessionBusiness _sessionBusiness,
            IUsersData _usersData,
            Business.Infaq.Interface.Model.Expired.AddRequest addRequest)
        {
            return await _addBusiness.AddAsync(_authorizationBusiness, _infaqsData, _sessionBusiness, _usersData, addRequest);
        }
    }
}
