using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static class Expire
    {
        internal static async Task<Response> AddAsync(
            IAuthorizationBusiness _authorizationBusiness,
            Business.Infaq.Interface.Expire.IAddBusiness _addBusiness,
            IInfaqData _infaqData,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            Business.Infaq.Interface.Model.Expire.AddRequest addRequest)
        {
            return await _addBusiness.AddAsync(_authorizationBusiness, _infaqData, _sessionBusiness, _userData, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            Business.Infaq.Interface.Expire.IApproveBusiness _approveBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Expire.ApproveRequest approveRequest)
        {
            return await _approveBusiness.ApproveAsync(_sessionBusiness, _userData, _infaqData, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            Business.Infaq.Interface.Expire.ICancelBusiness _cancelBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Expire.CancelRequest cancelRequest)
        {
            return await _cancelBusiness.CancelAsync(_sessionBusiness, _userData, _infaqData, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Expire.GetManyResponseRecord>> GetManyAsync(
            Business.Infaq.Interface.Expire.IGetManyBusiness _getManyBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Expire.GetManyRequest getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_infaqData, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Expire.GetManyNewResponseRecord>> GetManyNewAsync(
            Business.Infaq.Interface.Expire.IGetManyNewBusiness _getManyNewBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Expire.GetManyNewRequest getManyNewRequest)
        {
            return await _getManyNewBusiness.GetAsync(_infaqData, getManyNewRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Expire.GetOneResponse> GetOneAsync(
            Business.Infaq.Interface.Expire.IGetOneBusiness _getOneBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Expire.GetOneRequest getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_infaqData, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Expire.GetOneNewResponse> GetOneNewAsync(
            Business.Infaq.Interface.Expire.IGetOneNewBusiness _getOneNewBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Expire.GetOneNewRequest getOneNewRequest)
        {
            return await _getOneNewBusiness.GetAsync(_infaqData, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            Business.Infaq.Interface.Expire.IRejectBusiness _rejectBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Expire.RejectRequest rejectRequest)
        {
            return await _rejectBusiness.RejectAsync(_sessionBusiness, _userData, _infaqData, rejectRequest);
        }
    }

    internal static class Infaq
    {
        // todo apply [FromBody] to all
        // add nullable to all
        internal static async Task<Response> AddAnonymAsync(
            Business.Infaq.Interface.Infaq.IAddAnonymBusiness _addAnonymBusiness,
            ICaptchaData _captchaData,
            ISessionBusiness _sessionBusiness,
            IInfaqData _infaqData,
            [FromBody] Business.Infaq.Interface.Model.Infaq.AddByAnonymRequest? addByAnonymRequest)
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

    internal static class Success
    {
        internal static async Task<Response> AddAsync(
            IAuthorizationBusiness _authorizationBusiness,
            Business.Infaq.Interface.Success.IAddBusiness _addBusiness,
            IInfaqData _infaqData,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            Business.Infaq.Interface.Model.Success.AddRequest addRequest)
        {
            return await _addBusiness.AddAsync(_authorizationBusiness, _infaqData, _sessionBusiness, _userData, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            Business.Infaq.Interface.Success.IApproveBusiness _approveBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Success.ApproveRequest approveRequest)
        {
            return await _approveBusiness.ApproveAsync(_sessionBusiness, _userData, _infaqData, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            Business.Infaq.Interface.Success.ICancelBusiness _cancelBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Success.CancelRequest cancelRequest)
        {
            return await _cancelBusiness.CancelAsync(_sessionBusiness, _userData, _infaqData, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Success.GetManyResponseRecord>> GetManyAsync(
            Business.Infaq.Interface.Success.IGetManyBusiness _getManyBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Success.GetManyRequest getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_infaqData, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Success.GetManyNewResponseRecord>> GetManyNewAsync(
            Business.Infaq.Interface.Success.IGetManyNewBusiness _getManyNewBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Success.GetManyNewRequest getManyNewRequest)
        {
            return await _getManyNewBusiness.GetAsync(_infaqData, getManyNewRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Success.GetOneResponse> GetOneAsync(
            Business.Infaq.Interface.Success.IGetOneBusiness _getOneBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Success.GetOneRequest getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_infaqData, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Success.GetOneNewResponse> GetOneNewAsync(
            Business.Infaq.Interface.Success.IGetOneNewBusiness _getOneNewBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Success.GetOneNewRequest getOneNewRequest)
        {
            return await _getOneNewBusiness.GetAsync(_infaqData, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            Business.Infaq.Interface.Success.IRejectBusiness _rejectBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Success.RejectRequest rejectRequest)
        {
            return await _rejectBusiness.RejectAsync(_sessionBusiness, _userData, _infaqData, rejectRequest);
        }
    }

    internal static class Void
    {
        internal static async Task<Response> AddAsync(
            IAuthorizationBusiness _authorizationBusiness,
            Business.Infaq.Interface.Void.IAddBusiness _addBusiness,
            IInfaqData _infaqData,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            Business.Infaq.Interface.Model.Void.AddRequest addRequest)
        {
            return await _addBusiness.AddAsync(_authorizationBusiness, _infaqData, _sessionBusiness, _userData, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            Business.Infaq.Interface.Void.IApproveBusiness _approveBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Void.ApproveRequest approveRequest)
        {
            return await _approveBusiness.ApproveAsync(_sessionBusiness, _userData, _infaqData, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            Business.Infaq.Interface.Void.ICancelBusiness _cancelBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Void.CancelRequest cancelRequest)
        {
            return await _cancelBusiness.CancelAsync(_sessionBusiness, _userData, _infaqData, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Void.GetManyResponseRecord>> GetManyAsync(
            Business.Infaq.Interface.Void.IGetManyBusiness _getManyBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Void.GetManyRequest getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_infaqData, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Void.GetManyNewResponseRecord>> GetManyNewAsync(
            Business.Infaq.Interface.Void.IGetManyNewBusiness _getManyNewBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Void.GetManyNewRequest getManyNewRequest)
        {
            return await _getManyNewBusiness.GetAsync(_infaqData, getManyNewRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Void.GetOneResponse> GetOneAsync(
            Business.Infaq.Interface.Void.IGetOneBusiness _getOneBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Void.GetOneRequest getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_infaqData, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Void.GetOneNewResponse> GetOneNewAsync(
            Business.Infaq.Interface.Void.IGetOneNewBusiness _getOneNewBusiness,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Void.GetOneNewRequest getOneNewRequest)
        {
            return await _getOneNewBusiness.GetAsync(_infaqData, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            Business.Infaq.Interface.Void.IRejectBusiness _rejectBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            IInfaqData _infaqData,
            Business.Infaq.Interface.Model.Void.RejectRequest rejectRequest)
        {
            return await _rejectBusiness.RejectAsync(_sessionBusiness, _userData, _infaqData, rejectRequest);
        }
    }
}
