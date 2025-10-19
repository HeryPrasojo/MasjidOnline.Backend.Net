using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.User;

public class LogoutBusiness : ILogoutBusiness
{
    public async Task<Response> LogoutAsync(Session.Interface.Model.Session session, IData _data)
    {
        session.UserId = Constant.UserId.Anonymous;

        await _data.Session.Session.SetUserIdAndSaveAsync(session.Id, session.UserId, DateTime.UtcNow);

        return new Response
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
