using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static class Expire
    {
        internal static async Task<Response> AddAsync(
            IAuthorizationBusiness _authorizationBusiness,
            IAddBusiness _addBusiness,
            IInfaqData _infaqData,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            AddRequest addRequest)
        {
            return await _addBusiness.AddAsync(_authorizationBusiness, _infaqData, _sessionBusiness, _userData, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IApproveBusiness _approveBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            ApproveRequest approveRequest)
        {
            return await _approveBusiness.ApproveAsync(_sessionBusiness, _userData, _infaqData, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            ICancelBusiness _cancelBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            CancelRequest cancelRequest)
        {
            return await _cancelBusiness.CancelAsync(_sessionBusiness, _userData, _infaqData, cancelRequest);
        }

        internal static async Task<GetManyResponse<GetManyResponseRecord>> GetManyAsync(
            IGetManyBusiness _getManyBusiness,
            IInfaqData _infaqData,
            GetManyRequest getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_infaqData, getManyRequest);
        }

        internal static async Task<GetManyResponse<GetManyNewResponseRecord>> GetManyNewAsync(
            IGetManyNewBusiness _getManyNewBusiness,
            IInfaqData _infaqData,
            GetManyNewRequest getManyNewRequest)
        {
            return await _getManyNewBusiness.GetAsync(_infaqData, getManyNewRequest);
        }

        internal static async Task<GetOneResponse> GetOneAsync(
            IGetOneBusiness _getOneBusiness,
            IInfaqData _infaqData,
            GetOneRequest getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_infaqData, getOneRequest);
        }

        internal static async Task<GetOneNewResponse> GetOneNewAsync(
            IGetOneNewBusiness _getOneNewBusiness,
            IInfaqData _infaqData,
            GetOneNewRequest getOneNewRequest)
        {
            return await _getOneNewBusiness.GetAsync(_infaqData, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            IRejectBusiness _rejectBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            RejectRequest rejectRequest)
        {
            return await _rejectBusiness.RejectAsync(_sessionBusiness, _userData, _infaqData, rejectRequest);
        }
    }

    internal static class Infaq
    {
        internal static async Task<Response> AddAnonymAsync(
            Business.Infaq.Interface.Infaq.IAddAnonymBusiness _addAnonymBusiness,
            ICaptchaData _captchaData,
            ISessionBusiness _sessionBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Infaq.AddByAnonymRequest addByAnonymRequest)
        {
            return await _addAnonymBusiness.AddAsync(_captchaData, _sessionBusiness, _infaqData, addByAnonymRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Infaq.GetManyResponseRecord>> GetManyAsync(
            Business.Infaq.Interface.Infaq.IGetManyBusiness _getManyBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Infaq.GetManyRequest getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_infaqData, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Infaq.GetManyDueResponseRecord>> GetManyDueAsync(
            Business.Infaq.Interface.Infaq.IGetManyDueBusiness _getManyDueBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Infaq.GetManyDueRequest getManyDueRequest)
        {
            return await _getManyDueBusiness.GetAsync(_infaqData, getManyDueRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Infaq.GetOneResponse> GetOneAsync(
            Business.Infaq.Interface.Infaq.IGetOneBusiness _getOneBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Infaq.GetOneRequest getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_infaqData, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Infaq.GetOneDueResponse> GetOneDueAsync(
            Business.Infaq.Interface.Infaq.IGetOneDueBusiness _getOneDueBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Infaq.GetOneDueRequest getOneDueRequest)
        {
            return await _getOneDueBusiness.GetAsync(_infaqData, getOneDueRequest);
        }
    }
}
