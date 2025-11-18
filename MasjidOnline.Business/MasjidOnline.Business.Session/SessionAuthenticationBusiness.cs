using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionAuthenticationBusiness(IService _service) : ISessionAuthenticationBusiness
{
    // todo move culture to /session/culture/set
    public async Task AuthenticateAsync(
        Interface.Model.Session session,
        IData _data,
        string? codeBase64,
        string? cultureName,
        [CallerArgumentExpression(nameof(codeBase64))] string? codeBase64Expression = default)
    {
        if (codeBase64 == default) return;


        var requestSessionIdBytes = _service.FieldValidator.ValidateRequiredBase64(codeBase64, 128, codeBase64Expression);

        var decryptedRquestSessionIdBytes = _service.Encryption128b256kService.Decrypt(requestSessionIdBytes);

        if (decryptedRquestSessionIdBytes == default) return;


        var sessionEntity = await _data.Session.Session.GetForStartAsync(decryptedRquestSessionIdBytes);

        if (sessionEntity == default)
        {
            // hack log event

            throw new SessionExpireException(default);
        }



        await _data.Transaction.BeginAsync(_data.User, _data.Session);

        UserPreferenceApplicationCulture? userPreferenceApplicationCulture = default;

        session.Id = sessionEntity.Id;
        session.UserId = sessionEntity.UserId;

        if (cultureName.IsNullOrEmptyOrWhiteSpace())
        {
            session.CultureInfo = Mapper.Mapper.User.UserPreferenceApplicationCulture[sessionEntity.ApplicationCulture];
        }
        else
        {
            session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfos[cultureName!];

            userPreferenceApplicationCulture = Mapper.Mapper.User.UserPreferenceApplicationCulture[session.CultureInfo];

            if (!session.IsUserAnonymous)
            {
                _data.User.UserPreference.SetApplicationCulture(session.UserId, userPreferenceApplicationCulture.Value);
            }
        }

        _data.Session.Session.SetForAuthenticate(session.Id, DateTime.UtcNow, userPreferenceApplicationCulture);

        await _data.Transaction.CommitAsync();
    }
}