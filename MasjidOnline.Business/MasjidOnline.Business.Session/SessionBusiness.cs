using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionBusiness(IService _service, IIdGenerator _idGenerator) : ISessionBusiness
{
    public async Task ChangeAsync(Interface.Model.Session session, IData _data)
    {
        var sessionEntity = new Entity.Session.Session
        {
            ApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo],
            DateTime = DateTime.UtcNow,
            Digest = _idGenerator.Session.SessionDigest,
            Id = _idGenerator.Session.SessionId,
            PreviousId = session.Id,
            UserId = session.UserId,
        };

        await _data.Session.Session.AddAsync(sessionEntity);


        session.Digest = sessionEntity.Digest;
        session.Id = sessionEntity.Id;
    }

    public async Task ChangeAndSaveAsync(Interface.Model.Session session, IData _data)
    {
        await ChangeAsync(session, _data);

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
            session.UserId = Model.Constant.UserId.Anonymous;

            if (cultureName.IsNullOrEmptyOrWhiteSpace())
            {
                session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfoEnglish;
            }
            else
            {
                session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfos[cultureName!];
            }

            await ChangeAndSaveAsync(session, _data);
        }
        else
        {
            var requestSessionIdBytes = _service.FieldValidator.ValidateRequiredBase64(idBase64, 128, idBase64Expression);

            var decryptedRquestSessionIdBytes = _service.Encryption128128.Decrypt(requestSessionIdBytes);

            var sessionEntity = await _data.Session.Session.GetForStartAsync(decryptedRquestSessionIdBytes);

            if (sessionEntity == default)
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

                await ChangeAndSaveAsync(session, _data);

                // hack log event
            }
            else
            {
                // hack update Session.DateTime

                if (sessionEntity.DateTime < DateTime.UtcNow.AddDays(-32)) throw new SessionExpireException(idBase64Expression);

                session.Digest = decryptedRquestSessionIdBytes;
                session.Id = sessionEntity.Id;
                session.UserId = sessionEntity.UserId;

                if (sessionEntity.DateTime < DateTime.UtcNow.AddDays(-16))
                {
                    await _data.Transaction.BeginAsync(_data.Session, _data.User);

                    if (cultureName.IsNullOrEmptyOrWhiteSpace())
                    {
                        session.CultureInfo = Model.Constant.UserPreferenceApplicationCulture[sessionEntity.ApplicationCulture];
                    }
                    else
                    {
                        session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfos[cultureName!];

                        if (!session.IsUserAnonymous)
                        {
                            var userPreferenceApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo];

                            _data.User.UserPreference.SetApplicationCulture(session.UserId, userPreferenceApplicationCulture);
                        }
                    }

                    await ChangeAsync(session, _data);

                    await _data.Transaction.CommitAsync();
                }
                else
                {
                    if (cultureName.IsNullOrEmptyOrWhiteSpace())
                    {
                        session.CultureInfo = Model.Constant.UserPreferenceApplicationCulture[sessionEntity.ApplicationCulture];
                    }
                    else
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
                }
            }
        }
    }
}