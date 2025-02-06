using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
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

    internal static async Task<Response> LoginAsync(ILoginBusiness loginBusiness)
    {
        // undone 4
        return default;
    }

    internal static async Task<Response> SetPasswordAsync(
        Session session,
        ISessionsData sessionsData,
        IUsersData usersData,
        IPasswordSetBusiness passwordSetBusiness,
        SetPasswordRequest setPasswordRequest)
    {
        return await passwordSetBusiness.SetAsync(session, sessionsData, usersData, setPasswordRequest);
    }
}
