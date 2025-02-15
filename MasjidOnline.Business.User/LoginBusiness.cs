using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Business.User;

public class LoginBusiness(IHash512Service _hash512Service) : ILoginBusiness
{
    public async Task<Response> LoginAsync(IUsersData _usersData, ISessionBusiness _sessionBusiness, LoginRequest loginRequest)
    {
        var userEmailAddress = await _usersData.UserEmailAddress.GetForLoginAsync(loginRequest.EmailAddress);

        if (userEmailAddress == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var user = await _usersData.User.GetForLoginAsync(userEmailAddress.UserId);

        if (user == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));

        if (user.Password == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var requestPasswordHashBytes = _hash512Service.Hash(loginRequest.Password);

        if (!requestPasswordHashBytes.SequenceEqual(user.Password)) throw new InputMismatchException(nameof(loginRequest.Password));


        await _sessionBusiness.ChangeAsync(userEmailAddress.UserId);

        return new()
        {
            ResultCode = ResponseResult.Success
        };
    }
}
