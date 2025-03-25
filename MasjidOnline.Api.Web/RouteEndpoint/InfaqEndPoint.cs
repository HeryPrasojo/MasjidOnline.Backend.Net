using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Databases;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static class Expire
    {
        internal static async Task<Response> AddAsync(
            IAuthorizationBusiness _authorizationBusiness,
            Business.Infaq.Interface.Expire.IAddBusiness _addBusiness,
            IInfaqDatabase _infaqDatabase,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.Infaq.Interface.Model.Expire.AddRequest? addRequest)
        {
            return await _addBusiness.AddAsync(_authorizationBusiness, _infaqDatabase, _sessionBusiness, _userDatabase, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            Business.Infaq.Interface.Expire.IApproveBusiness _approveBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Expire.ApproveRequest? approveRequest)
        {
            return await _approveBusiness.ApproveAsync(_sessionBusiness, _userDatabase, _infaqDatabase, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            Business.Infaq.Interface.Expire.ICancelBusiness _cancelBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Expire.CancelRequest? cancelRequest)
        {
            return await _cancelBusiness.CancelAsync(_sessionBusiness, _userDatabase, _infaqDatabase, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Expire.GetManyResponseRecord>> GetManyAsync(
            Business.Infaq.Interface.Expire.IGetManyBusiness _getManyBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Expire.GetManyRequest? getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_infaqDatabase, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Expire.GetManyNewResponseRecord>> GetManyNewAsync(
            Business.Infaq.Interface.Expire.IGetManyNewBusiness _getManyNewBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Expire.GetManyNewRequest? getManyNewRequest)
        {
            return await _getManyNewBusiness.GetAsync(_infaqDatabase, getManyNewRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Expire.GetOneResponse> GetOneAsync(
            Business.Infaq.Interface.Expire.IGetOneBusiness _getOneBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Expire.GetOneRequest? getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_infaqDatabase, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Expire.GetOneNewResponse> GetOneNewAsync(
            Business.Infaq.Interface.Expire.IGetOneNewBusiness _getOneNewBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Expire.GetOneNewRequest? getOneNewRequest)
        {
            return await _getOneNewBusiness.GetAsync(_infaqDatabase, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            Business.Infaq.Interface.Expire.IRejectBusiness _rejectBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Expire.RejectRequest? rejectRequest)
        {
            return await _rejectBusiness.RejectAsync(_sessionBusiness, _userDatabase, _infaqDatabase, rejectRequest);
        }
    }

    internal static class Infaq
    {
        internal static async Task<Response> AddAnonymAsync(
            Business.Infaq.Interface.Infaq.IAddAnonymBusiness _addAnonymBusiness,
            ICaptchaDatabase _captchaDatabase,
            ISessionBusiness _sessionBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Infaq.AddByAnonymRequest? addByAnonymRequest)
        {
            return await _addAnonymBusiness.AddAsync(_captchaDatabase, _sessionBusiness, _infaqDatabase, addByAnonymRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Infaq.GetManyResponseRecord>> GetManyAsync(
            Business.Infaq.Interface.Infaq.IGetManyBusiness _getManyBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Infaq.GetManyRequest? getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_infaqDatabase, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Infaq.GetManyDueResponseRecord>> GetManyDueAsync(
            Business.Infaq.Interface.Infaq.IGetManyDueBusiness _getManyDueBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Infaq.GetManyDueRequest? getManyDueRequest)
        {
            return await _getManyDueBusiness.GetAsync(_infaqDatabase, getManyDueRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Infaq.GetOneResponse> GetOneAsync(
            Business.Infaq.Interface.Infaq.IGetOneBusiness _getOneBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Infaq.GetOneRequest? getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_infaqDatabase, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Infaq.GetOneDueResponse> GetOneDueAsync(
            Business.Infaq.Interface.Infaq.IGetOneDueBusiness _getOneDueBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Infaq.GetOneDueRequest? getOneDueRequest)
        {
            return await _getOneDueBusiness.GetAsync(_infaqDatabase, getOneDueRequest);
        }
    }

    internal static class Success
    {
        internal static async Task<Response> AddAsync(
            IAuthorizationBusiness _authorizationBusiness,
            Business.Infaq.Interface.Success.IAddBusiness _addBusiness,
            IInfaqDatabase _infaqDatabase,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.Infaq.Interface.Model.Success.AddRequest? addRequest)
        {
            return await _addBusiness.AddAsync(_authorizationBusiness, _infaqDatabase, _sessionBusiness, _userDatabase, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            Business.Infaq.Interface.Success.IApproveBusiness _approveBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Success.ApproveRequest? approveRequest)
        {
            return await _approveBusiness.ApproveAsync(_sessionBusiness, _userDatabase, _infaqDatabase, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            Business.Infaq.Interface.Success.ICancelBusiness _cancelBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Success.CancelRequest? cancelRequest)
        {
            return await _cancelBusiness.CancelAsync(_sessionBusiness, _userDatabase, _infaqDatabase, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Success.GetManyResponseRecord>> GetManyAsync(
            Business.Infaq.Interface.Success.IGetManyBusiness _getManyBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Success.GetManyRequest? getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_infaqDatabase, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Success.GetManyNewResponseRecord>> GetManyNewAsync(
            Business.Infaq.Interface.Success.IGetManyNewBusiness _getManyNewBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Success.GetManyNewRequest? getManyNewRequest)
        {
            return await _getManyNewBusiness.GetAsync(_infaqDatabase, getManyNewRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Success.GetOneResponse> GetOneAsync(
            Business.Infaq.Interface.Success.IGetOneBusiness _getOneBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Success.GetOneRequest? getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_infaqDatabase, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Success.GetOneNewResponse> GetOneNewAsync(
            Business.Infaq.Interface.Success.IGetOneNewBusiness _getOneNewBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Success.GetOneNewRequest? getOneNewRequest)
        {
            return await _getOneNewBusiness.GetAsync(_infaqDatabase, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            Business.Infaq.Interface.Success.IRejectBusiness _rejectBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Success.RejectRequest? rejectRequest)
        {
            return await _rejectBusiness.RejectAsync(_sessionBusiness, _userDatabase, _infaqDatabase, rejectRequest);
        }
    }

    internal static class Void
    {
        internal static async Task<Response> AddAsync(
            IAuthorizationBusiness _authorizationBusiness,
            Business.Infaq.Interface.Void.IAddBusiness _addBusiness,
            IInfaqDatabase _infaqDatabase,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.Infaq.Interface.Model.Void.AddRequest? addRequest)
        {
            return await _addBusiness.AddAsync(_authorizationBusiness, _infaqDatabase, _sessionBusiness, _userDatabase, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            Business.Infaq.Interface.Void.IApproveBusiness _approveBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Void.ApproveRequest? approveRequest)
        {
            return await _approveBusiness.ApproveAsync(_sessionBusiness, _userDatabase, _infaqDatabase, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            Business.Infaq.Interface.Void.ICancelBusiness _cancelBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Void.CancelRequest? cancelRequest)
        {
            return await _cancelBusiness.CancelAsync(_sessionBusiness, _userDatabase, _infaqDatabase, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Void.GetManyResponseRecord>> GetManyAsync(
            Business.Infaq.Interface.Void.IGetManyBusiness _getManyBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Void.GetManyRequest? getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_infaqDatabase, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Void.GetManyNewResponseRecord>> GetManyNewAsync(
            Business.Infaq.Interface.Void.IGetManyNewBusiness _getManyNewBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Void.GetManyNewRequest? getManyNewRequest)
        {
            return await _getManyNewBusiness.GetAsync(_infaqDatabase, getManyNewRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Void.GetOneResponse> GetOneAsync(
            Business.Infaq.Interface.Void.IGetOneBusiness _getOneBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Void.GetOneRequest? getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_infaqDatabase, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Void.GetOneNewResponse> GetOneNewAsync(
            Business.Infaq.Interface.Void.IGetOneNewBusiness _getOneNewBusiness,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Void.GetOneNewRequest? getOneNewRequest)
        {
            return await _getOneNewBusiness.GetAsync(_infaqDatabase, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            Business.Infaq.Interface.Void.IRejectBusiness _rejectBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            IInfaqDatabase _infaqDatabase,
            [FromBody] Business.Infaq.Interface.Model.Void.RejectRequest? rejectRequest)
        {
            return await _rejectBusiness.RejectAsync(_sessionBusiness, _userDatabase, _infaqDatabase, rejectRequest);
        }
    }
}
