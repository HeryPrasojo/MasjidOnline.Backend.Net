using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Business.User;

public class LoginBusiness(IHash512Service _hash512Service) : ILoginBusiness
{
    public async Task<Response> LoginAsync(IUsersData _usersData, ISessionsData _sessionsData, Session session, LoginRequest loginRequest)
    {
        var userEmailAddress = await _usersData.UserEmailAddress.GetForLoginAsync(loginRequest.EmailAddress);

        if (userEmailAddress == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var user = await _usersData.User.GetForLoginAsync(userEmailAddress.UserId);

        if (user == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));

        if (user.Password == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var requestPasswordHashBytes = _hash512Service.Hash(loginRequest.Password);

        if (!requestPasswordHashBytes.SequenceEqual(user.Password)) throw new InputMismatchException(nameof(loginRequest.Password));


        var previousSessionId = session.Id;

        session.Id = _hash512Service.RandomDigestBytes;
        session.NewId = session.Id;
        session.UserId = userEmailAddress.UserId;


        var sessionEntity = new Entity.Sessions.Session
        {
            DateTime = DateTime.UtcNow,
            Id = session.Id,
            PreviousId = previousSessionId,
            UserId = session.UserId,
        };

        await _sessionsData.Session.AddAndSaveAsync(sessionEntity);

        return new()
        {
            ResultCode = ResponseResult.Success
        };
    }
}
