using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Business.User.User;

public class LoginBusiness(IHash512Service _hash512Service) : ILoginBusiness
{
    public async Task<Response> LoginAsync(IData _data, ISessionBusiness _sessionBusiness, LoginRequest? loginRequest)
    {
        var userId = await _data.User.UserEmailAddress.GetUserIdAsync(loginRequest.EmailAddress);

        if (userId == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var user = await _data.User.User.GetForLoginAsync(userId.Value);

        if (user == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));

        if (user.Password == default) throw new InputMismatchException(nameof(user.Password));


        var requestPasswordHashBytes = _hash512Service.Hash(loginRequest.Password);

        if (!requestPasswordHashBytes.SequenceEqual(user.Password)) throw new InputMismatchException(nameof(loginRequest.Password));


        await _sessionBusiness.ChangeAndSaveAsync(userId.Value);

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
