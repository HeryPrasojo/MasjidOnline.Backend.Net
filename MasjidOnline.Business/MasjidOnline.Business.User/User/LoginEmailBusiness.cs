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

public class LoginEmailBusiness(ISessionBusiness _sessionBusiness, IService _service) : ILoginEmailBusiness
{
    // undone
    public async Task<Response> LoginAsync(IData _data, Session.Interface.Model.Session session, LoginRequest? loginRequest)
    {
        loginRequest = _service.FieldValidator.ValidateRequired(loginRequest);
        loginRequest.EmailAddress = _service.FieldValidator.ValidateRequiredEmailAddress(loginRequest.EmailAddress);
        loginRequest.Password = _service.FieldValidator.ValidateRequiredTextDb255(loginRequest.Password);

        var userId = await _data.User.UserEmailAddress.GetUserIdAsync(loginRequest.EmailAddress);

        if (userId == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var user = await _data.User.User.GetForLoginAsync(userId.Value);

        if (user == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));

        if (user.Password == default) throw new InputMismatchException(nameof(user.Password));


        var requestPasswordHashBytes = _service.Hash512.Hash(loginRequest.Password);

        if (!requestPasswordHashBytes.SequenceEqual(user.Password)) throw new InputMismatchException(nameof(loginRequest.Password));


        session.UserId = userId.Value;

        await _sessionBusiness.ChangeAndSaveAsync(session, _data);

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
