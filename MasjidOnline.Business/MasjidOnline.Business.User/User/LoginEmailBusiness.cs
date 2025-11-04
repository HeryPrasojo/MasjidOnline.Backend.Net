using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Mapper;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Event;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class LoginEmailBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : ILoginEmailBusiness
{
    public async Task<Response> LoginAsync(IData _data, Session.Interface.Model.Session session, LoginRequest? loginRequest)
    {
        _authorizationBusiness.AuthorizeAnonymous(session);

        loginRequest = _service.FieldValidator.ValidateRequired(loginRequest);
        loginRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(loginRequest.CaptchaToken);
        loginRequest.EmailAddress = _service.FieldValidator.ValidateRequiredEmailAddress(loginRequest.EmailAddress);
        loginRequest.Password = _service.FieldValidator.ValidateRequiredTextDb255(loginRequest.Password);
        loginRequest.Client = _service.FieldValidator.ValidateRequiredEnum(loginRequest.Client);

        _service.FieldValidator.ValidateRequired(loginRequest.Client, m => m != Event.Interface.Model.UserLoginClient.Default);

        var userId = await _data.User.UserEmailAddress.GetUserIdAsync(loginRequest.EmailAddress);

        if (userId == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));


        var isCaptchaVerified = await _service.Captcha.VerifyAsync(loginRequest.CaptchaToken, "setPassword");

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(loginRequest.CaptchaToken));


        var user = await _data.User.User.GetForLoginAsync(userId.Value);

        if (user == default) throw new InputMismatchException(nameof(loginRequest.EmailAddress));

        if (user.Password == default) throw new InputMismatchException(nameof(user.Password));


        var requestPasswordHashBytes = _service.Hash512.Hash(loginRequest.Password);

        if (!requestPasswordHashBytes.SequenceEqual(user.Password)) throw new InputMismatchException(nameof(loginRequest.Password));


        var userPreferenceApplicationCulture = await _data.User.UserPreference.GetApplicationCultureAsync(userId.Value);

        await _data.Transaction.BeginAsync(_data.Session, _data.Event);

        var utcNow = DateTime.UtcNow;

        session.UserId = userId.Value;
        session.CultureInfo = UserMapper.UserPreferenceApplicationCulture[userPreferenceApplicationCulture];
        session.UserId = userId.Value;

        _data.Session.Session.SetForLogin(session.Id, session.UserId, utcNow, userPreferenceApplicationCulture);


        var userLogin = new UserLogin
        {
            DateTime = utcNow,
            Id = _data.IdGenerator.Event.UserLoginId,
            IpAddress = loginRequest.IpAddress,
            LocationAltitude = loginRequest.LocationAltitude,
            LocationAltitudePrecision = loginRequest.LocationAltitudePrecision,
            LocationLatitude = loginRequest.LocationLatitude,
            LocationLongitude = loginRequest.LocationLongitude,
            LocationPrecision = loginRequest.LocationPrecision,
            Client = EventMapper.UserLoginClient[loginRequest.Client.Value],
            SessionId = session.Id,
            UserAgent = loginRequest.UserAgent,
            UserId = session.UserId,
            UserIdString = loginRequest.EmailAddress,
        };

        await _data.Event.UserLogin.AddAsync(userLogin);

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
