using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Authorization;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Event;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class LoginBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : ILoginBusiness
{
    public async Task<Response<LoginResponse>> LoginAsync(IData _data, Model.Session.Session session, LoginRequest? loginRequest)
    {
        _authorizationBusiness.AuthorizeAnonymous(session);

        loginRequest = _service.FieldValidator.ValidateRequired(loginRequest);

        loginRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(loginRequest.CaptchaToken);
        loginRequest.ContactType = _service.FieldValidator.ValidateRequiredEnum(loginRequest.ContactType);
        loginRequest.Password = _service.FieldValidator.ValidateRequiredTextDb255(loginRequest.Password);
        loginRequest.Client = _service.FieldValidator.ValidateRequiredEnum(loginRequest.Client);


        var contactType = Mapper.Mapper.User.ContactType[loginRequest.ContactType.Value];

        loginRequest.Contact = contactType switch
        {
            Entity.User.ContactType.Email => _service.FieldValidator.ValidateRequiredEmailAddress(loginRequest.Contact),
            _ => throw new InputInvalidException(nameof(loginRequest.Contact)),
        };


        var isCaptchaVerified = await _service.Captcha.VerifyLoginAsync(loginRequest.CaptchaToken);

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(loginRequest.CaptchaToken));



        var userId = contactType switch
        {
            Entity.User.ContactType.Email => await _data.User.UserEmailAddress.GetUserIdAsync(loginRequest.Contact),
            _ => throw new ErrorException(nameof(contactType)),
        };

        if (userId == default) throw new InputMismatchException(nameof(loginRequest.Contact) + " or " + nameof(loginRequest.Password));


        var user = await _data.User.User.GetForLoginAsync(userId.Value);

        if (user == default) throw new InputMismatchException(nameof(loginRequest.Contact) + " or " + nameof(loginRequest.Password));

        if (user.Status != UserStatus.Active) throw new InputMismatchException(nameof(user.Status));

        if (user.Password == default) throw new InputMismatchException(nameof(user.Password));


        var requestPasswordHashBytes = _service.Hash512.Hash(loginRequest.Password);

        if (!requestPasswordHashBytes.SequenceEqual(user.Password))
            throw new InputMismatchException(nameof(loginRequest.Contact) + " or " + nameof(loginRequest.Password));


        UserInternalPermission? userInternalPermissionResponse = default;

        var userInternalPermission = await _data.Authorization.UserInternalPermission.FirstOrDefaultAsync(userId.Value);

        if (userInternalPermission != default)
        {
            userInternalPermissionResponse = new()
            {
                AccountancyExpenditureAdd = userInternalPermission.AccountancyExpenditureAdd,
                AccountancyExpenditureApprove = userInternalPermission.AccountancyExpenditureApprove,
                AccountancyExpenditureCancel = userInternalPermission.AccountancyExpenditureCancel,

                InfaqExpireAdd = userInternalPermission.InfaqExpireAdd,
                InfaqExpireApprove = userInternalPermission.InfaqExpireApprove,
                InfaqExpireCancel = userInternalPermission.InfaqExpireCancel,

                InfaqSuccessAdd = userInternalPermission.InfaqSuccessAdd,
                InfaqSuccessApprove = userInternalPermission.InfaqSuccessApprove,
                InfaqSuccessCancel = userInternalPermission.InfaqSuccessCancel,

                InfaqVoidAdd = userInternalPermission.InfaqVoidAdd,
                InfaqVoidApprove = userInternalPermission.InfaqVoidApprove,
                InfaqVoidCancel = userInternalPermission.InfaqVoidCancel,

                UserInternalAdd = userInternalPermission.UserInternalAdd,
                UserInternalApprove = userInternalPermission.UserInternalApprove,
                UserInternalCancel = userInternalPermission.UserInternalCancel,
            };
        }


        var userPreferenceApplicationCulture = await _data.User.UserData.GetApplicationCultureAsync(userId.Value);

        await _data.Transaction.BeginAsync(_data.Session, _data.Event);

        var utcNow = DateTime.UtcNow;

        session.UserId = userId.Value;

        if (userPreferenceApplicationCulture != default)
            session.CultureInfo = Mapper.Mapper.Session.UserPreferenceApplicationCulture[userPreferenceApplicationCulture.Value];

        _data.Session.Session.SetForLogin(session.Id, session.UserId, utcNow, userPreferenceApplicationCulture);


        var userLogin = new UserLogin
        {
            DateTime = utcNow,
            Contact = loginRequest.Contact,
            ContactType = contactType,
            Id = _data.IdGenerator.Event.UserLoginId,
            IpAddress = loginRequest.IpAddress,
            LocationAltitude = loginRequest.LocationAltitude,
            LocationAltitudePrecision = loginRequest.LocationAltitudePrecision,
            LocationLatitude = loginRequest.LocationLatitude,
            LocationLongitude = loginRequest.LocationLongitude,
            LocationPrecision = loginRequest.LocationPrecision,
            Client = Mapper.Mapper.Event.UserLoginClient[loginRequest.Client.Value],
            SessionId = session.Id,
            UserAgent = loginRequest.UserAgent,
            UserId = session.UserId,
        };

        await _data.Event.UserLogin.AddAsync(userLogin);

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                ApplicationCulture = (userPreferenceApplicationCulture == default)
                    ? null
                    : Mapper.Mapper.User.UserPreferenceApplicationCulture[userPreferenceApplicationCulture.Value],
                Permission = userInternalPermissionResponse,
                UserType = Mapper.Mapper.User.UserType[user.Type],
            },
        };
    }
}
