using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class SetPasswordBusiness(
    IService _service) : ISetPasswordBusiness
{
    public async Task<Response> SetAsync(Session.Interface.Model.Session session, IData _data, SetPasswordRequest? setPasswordRequest)
    {
        setPasswordRequest = _service.FieldValidator.ValidateRequired(setPasswordRequest);
        setPasswordRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(setPasswordRequest.CaptchaToken);
        var codeBytes = _service.FieldValidator.ValidateRequiredBase64(setPasswordRequest.PasswordCode, 88);
        setPasswordRequest.Password = _service.FieldValidator.ValidateRequiredPassword(setPasswordRequest.Password);
        setPasswordRequest.Password2 = _service.FieldValidator.ValidateRequired(setPasswordRequest.Password2);

        if (setPasswordRequest.Password != setPasswordRequest.Password2) throw new InputInvalidException(nameof(setPasswordRequest.Password2));


        var isCaptchaVerified = await _service.Captcha.VerifyAsync(setPasswordRequest.CaptchaToken, "setPassword");

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(setPasswordRequest.CaptchaToken));


        var userId = await _data.User.PasswordCode.GetUserIdForSetPasswordAsync(codeBytes);

        if (userId == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (!session.IsUserAnonymous)
        {
            if (userId.Value != session.UserId) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));
        }


        var code = await _data.User.PasswordCode.GetLatestCodeForSetPasswordAsync(userId.Value);

        if (code == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (!code.SequenceEqual(codeBytes)) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));



        var utcNow = DateTime.UtcNow;

        var userStatus = await _data.User.User.GetStatusAsync(userId.Value);

        await _data.Transaction.BeginAsync(_data.User, _data.Audit, _data.Session);

        var passwordBytes = _service.Hash512.Hash(setPasswordRequest.Password);

        if (userStatus == UserStatus.New)
        {
            var firstPasswordUser = _data.User.User.SetFirstPassword(userId.Value, passwordBytes);

            await _data.Audit.UserLog.AddSetFirstPasswordAsync(_data.IdGenerator.Audit.UserLogId, utcNow, userId.Value, firstPasswordUser);
        }
        else if (userStatus == UserStatus.Active)
        {
            var passwordUser = _data.User.User.SetPassword(userId.Value, passwordBytes);

            await _data.Audit.UserLog.AddSetPasswordAsync(_data.IdGenerator.Audit.UserLogId, utcNow, userId.Value, passwordUser);
        }

        else throw new DataMismatchException(nameof(userStatus));


        _data.User.PasswordCode.SetUseDateTime(codeBytes, utcNow);


        if (session.IsUserAnonymous)
        {
            var userPreferenceApplicationCulture = await _data.User.UserPreference.GetApplicationCultureAsync(userId.Value);

            session.CultureInfo = Mapper.Mapper.User.UserPreferenceApplicationCulture[userPreferenceApplicationCulture];
            session.UserId = userId.Value;

            _data.Session.Session.SetForSetPassword(session.Id, session.UserId, utcNow, userPreferenceApplicationCulture);
        }

        await _data.Transaction.CommitAsync();

        return new Response()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
