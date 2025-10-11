using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionAuthenticationBusiness(IService _service, IIdGenerator _idGenerator) : ISessionAuthenticationBusiness
{
    private async Task AddAndSaveAsync(Interface.Model.Session session, IData _data)
    {
        var sessionEntity = new Entity.Session.Session
        {
            ApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo],
            DateTime = DateTime.UtcNow,
            Code = _service.Hash512.RandomByteArray,
            Id = _idGenerator.Session.SessionId,
            UserId = session.UserId,
        };

        await _data.Session.Session.AddAndSaveAsync(sessionEntity);


        session.Code = sessionEntity.Code;
        session.Id = sessionEntity.Id;
    }

    public async Task<string?> StartAsync(Interface.Model.Session session, IData _data, string? idBase64, string? cultureName, [CallerArgumentExpression(nameof(idBase64))] string? idBase64Expression = default)
    {
        if (idBase64 == default) return await CreateAnonymous(session, _data, cultureName);


        var requestSessionIdBytes = _service.FieldValidator.ValidateRequiredBase64(idBase64, 128, idBase64Expression);

        var decryptedRquestSessionIdBytes = _service.Encryption128b256kService.Decrypt(requestSessionIdBytes);

        if (decryptedRquestSessionIdBytes == default) throw new SessionExpireException(default);


        var sessionEntity = await _data.Session.Session.GetForStartAsync(decryptedRquestSessionIdBytes);

        if (sessionEntity == default)
        {
            // hack log event

            return await CreateAnonymous(session, _data, cultureName);
        }


        await _data.Session.Session.SetDateTimeAsync(sessionEntity.Id, DateTime.UtcNow);

        session.Code = decryptedRquestSessionIdBytes;
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

        return default;
    }

    private async Task<string> CreateAnonymous(Interface.Model.Session session, IData _data, string? cultureName)
    {
        session.UserId = Model.Constant.UserId.Anonymous;

        if (cultureName.IsNullOrEmptyOrWhiteSpace())
        {
            session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfoEnglish;
        }
        else
        {
            session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfos[cultureName!];
        }

        await AddAndSaveAsync(session, _data);


        return Convert.ToBase64String(_service.Encryption128b256kService.Encrypt(session.Code.Span));
    }
}