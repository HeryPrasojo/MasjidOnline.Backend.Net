using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class SetPasswordBusiness(
    IIdGenerator _idGenerator,
    IService _service) : ISetPasswordBusiness
{
    public async Task<Response> SetAsync(Session.Interface.Model.Session session, IData _data, SetPasswordRequest? setPasswordRequest)
    {
        setPasswordRequest = _service.FieldValidator.ValidateRequired(setPasswordRequest);

        setPasswordRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(setPasswordRequest.CaptchaToken);
        var codeBytes = _service.FieldValidator.ValidateRequiredHex(setPasswordRequest.PasswordCode, 128);
        setPasswordRequest.Password = _service.FieldValidator.ValidateRequiredPassword(setPasswordRequest.Password);
        setPasswordRequest.Password2 = _service.FieldValidator.ValidateRequired(setPasswordRequest.Password2);

        if (setPasswordRequest.Password != setPasswordRequest.Password2) throw new InputInvalidException(nameof(setPasswordRequest.Password2));


        if (session.Id == default)
        {
            var isVerified = await _service.Captcha.VerifyAsync(setPasswordRequest.CaptchaToken, "setPassword");

            if (!isVerified) throw new InputMismatchException(nameof(setPasswordRequest.CaptchaToken));
        }


        var userId = await _data.User.PasswordCode.GetUserIdForSetPasswordAsync(codeBytes);

        if (userId == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));


        var code = await _data.User.PasswordCode.GetLatestCodeForSetPasswordAsync(userId.Value);

        if (code == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (code.SequenceEqual(codeBytes)) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));


        var utcNow = DateTime.UtcNow;

        await _data.Transaction.BeginAsync(_data.User, _data.Audit, _data.Session);

        var passwordBytes = _service.Hash512.Hash(setPasswordRequest.Password);

        var user = _data.User.User.SetFirstPassword(userId.Value, passwordBytes);


        await _data.Audit.UserLog.AddSetFirstPasswordAsync(_idGenerator.Audit.UserLogId, utcNow, userId.Value, user);


        _data.User.PasswordCode.SetUseDateTime(codeBytes, utcNow);


        if (session.Id == default)
        {
            session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfoEnglish;
            session.Id = _idGenerator.Session.SessionId;
            session.UserId = userId.Value;


            var sessionEntity = new Entity.Session.Session
            {
                ApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo],
                DateTime = utcNow,
                Code = _service.Hash512.RandomByteArray,
                Id = session.Id,
                UserId = session.UserId,
            };

            await _data.Session.Session.AddAsync(sessionEntity);
        }
        else
        {

        }

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
