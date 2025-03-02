using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Users;
using MasjidOnline.Business.User.Interface.Model.Users.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    internal static async Task<Response> AddAsync(
        IAddBusiness addBusiness,
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        AddRequest addRequest)
    {
        return await addBusiness.AddAsync(_sessionBusiness, _usersData, addRequest);
    }

    internal static async Task<Response> LoginAsync(
        IUserLoginBusiness _userLoginBusiness,
        IUsersData _usersData,
        ISessionBusiness _sessionBusiness,
        LoginRequest loginRequest)
    {
        return await _userLoginBusiness.LoginAsync(_usersData, _sessionBusiness, loginRequest);
    }

    internal static async Task<Response> SetPasswordAsync(
        IDataTransaction _dataTransaction,
        ISessionBusiness _sessionBusiness,
        ISessionsData _sessionsData,
        IUsersData _usersData,
        IUserSetPasswordBusiness _userSetPasswordBusiness,
        SetPasswordRequest setPasswordRequest)
    {
        return await _userSetPasswordBusiness.SetAsync(_dataTransaction, _sessionBusiness, _sessionsData, _usersData, setPasswordRequest);
    }
}
