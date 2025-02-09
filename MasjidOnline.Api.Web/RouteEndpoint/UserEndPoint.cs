using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    // undone 2 authorization
    internal static async Task<Response> Addsync(IAdditionBusiness _additionBusiness, IUsersData _usersData, AddRequest addRequest)
    {
        return await _additionBusiness.AddAsync(_usersData, addRequest);
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
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        IPasswordSetBusiness _passwordSetBusiness,
        SetPasswordRequest setPasswordRequest)
    {
        return await _passwordSetBusiness.SetAsync(_sessionBusiness, _usersData, setPasswordRequest);
    }
}
