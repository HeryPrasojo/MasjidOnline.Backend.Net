using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    internal static async Task<Response> Addsync(
        IUserAddBusiness _userAddBusiness,
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        AddByInternalRequest addByInternalRequest)
    {
        return await _userAddBusiness.AddByInternalAsync(_sessionBusiness, _usersData, addByInternalRequest);
    }

    internal static async Task<Response> LoginAsync(
        ILoginBusiness _loginBusiness,
        IUsersData _usersData,
        ISessionBusiness _sessionBusiness,
        LoginRequest loginRequest)
    {
        return await _loginBusiness.LoginAsync(_usersData, _sessionBusiness, loginRequest);
    }

    internal static async Task<Response> SetPasswordAsync(
        IDataTransaction _dataTransaction,
        ISessionBusiness _sessionBusiness,
        ISessionsData _sessionsData,
        IUsersData _usersData,
        IPasswordSetBusiness _passwordSetBusiness,
        SetPasswordRequest setPasswordRequest)
    {
        return await _passwordSetBusiness.SetAsync(_dataTransaction, _sessionBusiness, _sessionsData, _usersData, setPasswordRequest);
    }
}
