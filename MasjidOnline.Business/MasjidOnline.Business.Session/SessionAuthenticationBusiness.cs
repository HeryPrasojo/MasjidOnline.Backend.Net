using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionAuthenticationBusiness(IService _service) : ISessionAuthenticationBusiness
{
    public async Task<bool> AuthenticateAsync(
        Interface.Model.Session session,
        IData _data,
        string? codeBase64,
        string? cultureName,
        string requestPath,
        [CallerArgumentExpression(nameof(codeBase64))] string? idBase64Expression = default)
    {
        if (codeBase64 == default)
        {
            if (requestPath != "/session/create") return false;

            return true;
        }


        var requestSessionIdBytes = _service.FieldValidator.ValidateRequiredBase64(codeBase64, 128, idBase64Expression);

        var decryptedRquestSessionIdBytes = _service.Encryption128b256kService.Decrypt(requestSessionIdBytes);

        if (decryptedRquestSessionIdBytes == default) return false;


        var sessionEntity = await _data.Session.Session.GetForStartAsync(decryptedRquestSessionIdBytes);

        if (sessionEntity == default)
        {
            // hack log event

            throw new SessionExpireException(default);
        }


        await _data.Session.Session.SetDateTimeAsync(sessionEntity.Id, DateTime.UtcNow);

        session.Id = sessionEntity.Id;
        session.UserId = sessionEntity.UserId;

        if (!cultureName.IsNullOrEmptyOrWhiteSpace())
        {
            await _data.Transaction.BeginAsync(_data.Session, _data.User);

            session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfos[cultureName!];

            var userPreferenceApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo];

            if (!session.IsUserAnonymous)
            {
                _data.User.UserPreference.SetApplicationCulture(session.UserId, userPreferenceApplicationCulture);
            }

            _data.Session.Session.SetApplicationCulture(session.Id, userPreferenceApplicationCulture);

            await _data.Transaction.CommitAsync();
        }

        return true;
    }
}