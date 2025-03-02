using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Business.User.User;

public class UserLoginBusiness(IHash512Service _hash512Service) : IUserLoginBusiness
{
    public async Task<Response> LoginAsync(IUserData _userData, ISessionBusiness _sessionBusiness, LoginRequest loginRequest)
    {
        var userEmailAddress = await _userData.UserEmailAddress.GetForLoginAsync(loginRequest.EmailAddress);

        if (userEmailAddress == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var user = await _userData.User.GetForLoginAsync(userEmailAddress.UserId);

        if (user == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));

        if (user.Password == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var requestPasswordHashBytes = _hash512Service.Hash(loginRequest.Password);

        if (!requestPasswordHashBytes.SequenceEqual(user.Password)) throw new InputMismatchException(nameof(loginRequest.Password));


        await _sessionBusiness.ChangeAndSaveAsync(userEmailAddress.UserId);

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
