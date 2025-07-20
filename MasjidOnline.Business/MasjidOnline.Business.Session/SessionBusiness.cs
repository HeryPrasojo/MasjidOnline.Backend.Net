using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionBusiness(IService _service, IIdGenerator _idGenerator) : ISessionBusiness
{
    public async Task ChangeAsync(Interface.Model.Session session, IData _data, int userId)
    {
        var sessionEntity = new Entity.Session.Session
        {
            ApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo],
            DateTime = DateTime.UtcNow,
            Digest = _idGenerator.Session.SessionDigest,
            Id = _idGenerator.Session.SessionId,
            PreviousId = session.Id,
            UserId = userId,
        };

        await _data.Session.Session.AddAsync(sessionEntity);


        session.Digest = sessionEntity.Digest;
        session.Id = sessionEntity.Id;
        session.UserId = sessionEntity.UserId;
    }

    public async Task ChangeAndSaveAsync(Interface.Model.Session session, IData _data, int userId)
    {
        await ChangeAsync(session, _data, userId);

        await _data.Session.SaveAsync();
    }

    public string GetDigestBase64(Interface.Model.Session session)
    {
        var encryptedDigest = _service.Encryption128128.Encrypt(session.Digest.Span);

        return Convert.ToBase64String(encryptedDigest);
    }

    public async Task StartAsync(Interface.Model.Session session, IData _data, string? idBase64, string? cultureName, [CallerArgumentExpression(nameof(idBase64))] string? idBase64Expression = default)
    {
        if (idBase64 == default)
        {
            if (string.IsNullOrWhiteSpace(cultureName))
            {
                session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfoEnglish;
            }
            else
            {
                session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfos[cultureName];
            }

            await ChangeAndSaveAsync(session, _data, Model.Constant.UserId.Anonymous);
        }
        else
        {
            var requestSessionIdBytes = _service.FieldValidator.ValidateRequiredBase64(idBase64, 128, idBase64Expression);

            var decryptedRquestSessionIdBytes = _service.Encryption128128.Decrypt(requestSessionIdBytes);

            var sessionEntity = await _data.Session.Session.GetForStartAsync(decryptedRquestSessionIdBytes);

            if (sessionEntity == default) -throw new SessionMismatchException(idBase64Expression);

            if (sessionEntity.DateTime < DateTime.UtcNow.AddDays(-32)) throw new SessionExpireException(idBase64Expression);

            session.Digest = requestSessionIdBytes;
            session.Id = sessionEntity.Id;
            session.UserId = sessionEntity.UserId;

            if (sessionEntity.DateTime < DateTime.UtcNow.AddDays(-16))
            {
                await _data.Transaction.BeginAsync(_data.Session, _data.User);

                if (string.IsNullOrWhiteSpace(cultureName))
                {
                    session.CultureInfo = Model.Constant.UserPreferenceApplicationCulture[sessionEntity.ApplicationCulture];
                }
                else
                {
                    session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfos[cultureName];

                    if (!session.IsUserAnonymous)
                    {
                        var userPreferenceApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo];

                        _data.User.UserPreference.SetApplicationCulture(session.UserId, userPreferenceApplicationCulture);
                    }
                }

                await ChangeAsync(session, _data, sessionEntity.UserId);

                await _data.Transaction.CommitAsync();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(cultureName))
                {
                    session.CultureInfo = Model.Constant.UserPreferenceApplicationCulture[sessionEntity.ApplicationCulture];
                }
                else
                {
                    await _data.Transaction.BeginAsync(_data.Session, _data.User);

                    session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfos[cultureName];

                    var userPreferenceApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo];

                    if (!session.IsUserAnonymous)
                    {
                        _data.User.UserPreference.SetApplicationCulture(session.UserId, userPreferenceApplicationCulture);
                    }

                    _data.Session.Session.SetApplicationCulture(session.Id, userPreferenceApplicationCulture);

                    await _data.Transaction.CommitAsync();
                }
            }
        }
    }
}