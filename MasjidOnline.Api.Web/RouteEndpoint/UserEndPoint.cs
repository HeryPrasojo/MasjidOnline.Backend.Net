using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    internal static class Internal
    {
        internal static async Task<Response> AddAsync(
            Business.User.Interface.Internal.IAddBusiness _addBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            Business.User.Interface.Model.Internal.AddRequest addRequest)
        {
            return await _addBusiness.AddAsync(_sessionBusiness, _userData, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            Business.User.Interface.Internal.IApproveBusiness _approveBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            Business.User.Interface.Model.Internal.ApproveRequest approveRequest)
        {
            return await _approveBusiness.ApproveAsync(_sessionBusiness, _userData, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            Business.User.Interface.Internal.ICancelBusiness _cancelBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            Business.User.Interface.Model.Internal.CancelRequest cancelRequest)
        {
            return await _cancelBusiness.CancelAsync(_sessionBusiness, _userData, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.User.Interface.Model.Internal.GetManyResponseRecord>> GetManyAsync(
            ISessionBusiness _sessionBusiness,
            Business.User.Interface.Internal.IGetManyBusiness _getManyBusiness,
            IUserData _userData,
            Business.User.Interface.Model.Internal.GetManyRequest getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_sessionBusiness, _userData, getManyRequest);
        }

        internal static async Task<Business.User.Interface.Model.Internal.GetOneResponse> GetOneAsync(
            Business.User.Interface.Internal.IGetOneBusiness _getOneBusiness,
            IUserData _userData,
            Business.User.Interface.Model.Internal.GetOneRequest getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_userData, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            Business.User.Interface.Internal.IRejectBusiness _rejectBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            Business.User.Interface.Model.Internal.RejectRequest rejectRequest)
        {
            return await _rejectBusiness.RejectAsync(_sessionBusiness, _userData, rejectRequest);
        }
    }

    internal static class User
    {
        internal static async Task<Response> LoginAsync(
            Business.User.Interface.User.ILoginBusiness _loginBusiness,
            IUserData _userData,
            ISessionBusiness _sessionBusiness,
            Business.User.Interface.Model.User.LoginRequest loginRequest)
        {
            return await _loginBusiness.LoginAsync(_userData, _sessionBusiness, loginRequest);
        }

        internal static async Task<Response> SetPasswordAsync(
            IDataTransaction _dataTransaction,
            ISessionBusiness _sessionBusiness,
            ISessionData _sessionData,
            IUserData _userData,
            Business.User.Interface.User.ISetPasswordBusiness _setPasswordBusiness,
            Business.User.Interface.Model.User.SetPasswordRequest setPasswordRequest)
        {
            return await _setPasswordBusiness.SetAsync(_dataTransaction, _sessionBusiness, _sessionData, _userData, setPasswordRequest);
        }
    }
}
