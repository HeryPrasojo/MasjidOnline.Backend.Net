using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class LoginEmailBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : ILoginEmailBusiness
{
    // undone
    public async Task<Response> LoginAsync(IData _data, Session.Interface.Model.Session session, LoginRequest? loginRequest)
    {
        _authorizationBusiness.AuthorizeAnonymous(session);

        loginRequest = _service.FieldValidator.ValidateRequired(loginRequest);
        loginRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(loginRequest.CaptchaToken);
        loginRequest.EmailAddress = _service.FieldValidator.ValidateRequiredEmailAddress(loginRequest.EmailAddress);
        loginRequest.Password = _service.FieldValidator.ValidateRequiredTextDb255(loginRequest.Password);

        var userId = await _data.User.UserEmailAddress.GetUserIdAsync(loginRequest.EmailAddress);

        if (userId == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var isCaptchaVerified = await _service.Captcha.VerifyAsync(loginRequest.CaptchaToken, "setPassword");

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(loginRequest.CaptchaToken));


        var user = await _data.User.User.GetForLoginAsync(userId.Value);

        if (user == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));

        if (user.Password == default) throw new InputMismatchException(nameof(user.Password));


        var requestPasswordHashBytes = _service.Hash512.Hash(loginRequest.Password);

        if (!requestPasswordHashBytes.SequenceEqual(user.Password)) throw new InputMismatchException(nameof(loginRequest.Password));


        await _data.Transaction.BeginAsync(_data.Session);

        var userPreferenceApplicationCulture = await _data.User.UserPreference.GetApplicationCultureAsync(userId.Value);

        session.UserId = userId.Value;
        session.CultureInfo = Constant.UserPreferenceApplicationCulture[userPreferenceApplicationCulture];
        session.UserId = userId.Value;

        _data.Session.Session.SetForLogin(session.Id, session.UserId, DateTime.UtcNow, userPreferenceApplicationCulture);

        // undone log login

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
