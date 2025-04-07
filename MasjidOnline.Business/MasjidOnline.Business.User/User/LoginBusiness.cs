using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class LoginBusiness(ISessionBusiness _sessionBusiness, IService _service) : ILoginBusiness
{
    public async Task<Response> LoginAsync(IData _data, Session.Interface.Session session, LoginRequest? loginRequest)
    {
        var userId = await _data.User.UserEmailAddress.GetUserIdAsync(loginRequest.EmailAddress);

        if (userId == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var user = await _data.User.User.GetForLoginAsync(userId.Value);

        if (user == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));

        if (user.Password == default) throw new InputMismatchException(nameof(user.Password));


        var requestPasswordHashBytes = _service.Hash512.Hash(loginRequest.Password);

        if (!requestPasswordHashBytes.SequenceEqual(user.Password)) throw new InputMismatchException(nameof(loginRequest.Password));


        await _sessionBusiness.ChangeAndSaveAsync(session, _data, userId.Value);

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
