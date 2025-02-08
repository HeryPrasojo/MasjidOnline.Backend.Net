using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    internal static async Task<Response> Addsync(IAdditionBusiness additionBusiness, AddRequest addRequest)
    {
        // undone 2
        //additionBusiness.;

        return default;
    }

    internal static async Task<Response> LoginAsync(
        ILoginBusiness _loginBusiness,
        IUsersData _usersData,
        ISessionsData _sessionsData,
        ISessionBusiness _sessionBusiness,
        LoginRequest loginRequest)
    {
        return await _loginBusiness.LoginAsync(_usersData, _sessionsData, _sessionBusiness, loginRequest);
    }

    internal static async Task<Response> SetPasswordAsync(
        ISessionBusiness _sessionBusiness,
        ISessionsData _sessionsData,
        IUsersData _usersData,
        IPasswordSetBusiness _passwordSetBusiness,
        SetPasswordRequest setPasswordRequest)
    {
        return await _passwordSetBusiness.SetAsync(_sessionBusiness, _sessionsData, _usersData, setPasswordRequest);
    }
}
