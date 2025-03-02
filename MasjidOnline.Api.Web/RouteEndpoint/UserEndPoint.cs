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
