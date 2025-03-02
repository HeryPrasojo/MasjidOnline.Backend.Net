using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    internal static class Internal
    {
        internal static async Task<Response> AddAsync(
            Business.User.Interface.Internal.IAddBusiness addBusiness,
            ISessionBusiness _sessionBusiness,
            IUserData _userData,
            Business.User.Interface.Model.Internal.AddRequest addRequest)
        {
            return await addBusiness.AddAsync(_sessionBusiness, _userData, addRequest);
        }
    }

    internal static class User
    {
        internal static async Task<Response> LoginAsync(
            IUserLoginBusiness _userLoginBusiness,
            IUserData _userData,
            ISessionBusiness _sessionBusiness,
            LoginRequest loginRequest)
        {
            return await _userLoginBusiness.LoginAsync(_userData, _sessionBusiness, loginRequest);
        }

        internal static async Task<Response> SetPasswordAsync(
            IDataTransaction _dataTransaction,
            ISessionBusiness _sessionBusiness,
            ISessionData _sessionData,
            IUserData _userData,
            IUserSetPasswordBusiness _userSetPasswordBusiness,
            SetPasswordRequest setPasswordRequest)
        {
            return await _userSetPasswordBusiness.SetAsync(_dataTransaction, _sessionBusiness, _sessionData, _userData, setPasswordRequest);
        }
    }
}
