using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Databases;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    internal static class Internal
    {
        internal static async Task<Response> AddAsync(
            Business.User.Interface.Internal.IAddBusiness _addBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.User.Interface.Model.Internal.AddRequest? addRequest)
        {
            return await _addBusiness.AddAsync(_sessionBusiness, _userDatabase, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            Business.User.Interface.Internal.IApproveBusiness _approveBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.User.Interface.Model.Internal.ApproveRequest? approveRequest)
        {
            return await _approveBusiness.ApproveAsync(_sessionBusiness, _userDatabase, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            Business.User.Interface.Internal.ICancelBusiness _cancelBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.User.Interface.Model.Internal.CancelRequest? cancelRequest)
        {
            return await _cancelBusiness.CancelAsync(_sessionBusiness, _userDatabase, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.User.Interface.Model.Internal.GetManyResponseRecord>> GetManyAsync(
            ISessionBusiness _sessionBusiness,
            Business.User.Interface.Internal.IGetManyBusiness _getManyBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.User.Interface.Model.Internal.GetManyRequest? getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_sessionBusiness, _userDatabase, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.User.Interface.Model.Internal.GetManyNewResponseRecord>> GetManyNewAsync(
            Business.User.Interface.Internal.IGetManyNewBusiness _getManyNewBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.User.Interface.Model.Internal.GetManyNewRequest? getManyNewRequest)
        {
            return await _getManyNewBusiness.GetAsync(_userDatabase, getManyNewRequest);
        }

        internal static async Task<Business.User.Interface.Model.Internal.GetOneResponse> GetOneAsync(
            Business.User.Interface.Internal.IGetOneBusiness _getOneBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.User.Interface.Model.Internal.GetOneRequest? getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_userDatabase, getOneRequest);
        }

        internal static async Task<Business.User.Interface.Model.Internal.GetOneNewResponse> GetOneNewAsync(
            Business.User.Interface.Internal.IGetOneNewBusiness _getOneNewBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.User.Interface.Model.Internal.GetOneNewRequest? getOneNewRequest)
        {
            return await _getOneNewBusiness.GetAsync(_userDatabase, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            Business.User.Interface.Internal.IRejectBusiness _rejectBusiness,
            ISessionBusiness _sessionBusiness,
            IUserDatabase _userDatabase,
            [FromBody] Business.User.Interface.Model.Internal.RejectRequest? rejectRequest)
        {
            return await _rejectBusiness.RejectAsync(_sessionBusiness, _userDatabase, rejectRequest);
        }
    }

    internal static class User
    {
        internal static async Task<Response> LoginAsync(
            Business.User.Interface.User.ILoginBusiness _loginBusiness,
            IUserDatabase _userDatabase,
            ISessionBusiness _sessionBusiness,
            [FromBody] Business.User.Interface.Model.User.LoginRequest? loginRequest)
        {
            return await _loginBusiness.LoginAsync(_userDatabase, _sessionBusiness, loginRequest);
        }

        internal static async Task<Response> SetPasswordAsync(
            IDataTransaction _dataTransaction,
            ISessionBusiness _sessionBusiness,
            ISessionDatabase _sessionDatabase,
            IUserDatabase _userDatabase,
            Business.User.Interface.User.ISetPasswordBusiness _setPasswordBusiness,
            [FromBody] Business.User.Interface.Model.User.SetPasswordRequest? setPasswordRequest)
        {
            return await _setPasswordBusiness.SetAsync(_dataTransaction, _sessionBusiness, _sessionDatabase, _userDatabase, setPasswordRequest);
        }
    }
}
