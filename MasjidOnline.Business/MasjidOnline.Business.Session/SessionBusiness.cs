using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Model.Extensions;
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
            ApplicationCulture = Constant.StringMapper.UserPreferenceApplicationCulture.FromCultureName[session.ApplicationCultureName],
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

    public async Task StartAsync(Interface.Model.Session session, IData _data, string? idBase64, [CallerArgumentExpression(nameof(idBase64))] string? idBase64Expression = default)
    {
        if (idBase64 == default)
        {
            session.ApplicationCultureName = Constant.DefaultUserPreferenceApplicationCulture;

            await ChangeAndSaveAsync(session, _data, Constant.UserId.Anonymous);
        }
        else
        {
            var requestSessionIdBytes = _service.FieldValidator.ValidateRequiredBase64(idBase64, 128, idBase64Expression);

            var decryptedRquestSessionIdBytes = _service.Encryption128128.Decrypt(requestSessionIdBytes);

            var sessionEntity = await _data.Session.Session.GetForStartAsync(decryptedRquestSessionIdBytes);

            if (sessionEntity == default) throw new SessionMismatchException(idBase64Expression);


            if (sessionEntity.DateTime < DateTime.UtcNow.AddDays(-32))
            {
                throw new SessionExpireException(idBase64Expression);
            }
            else if (sessionEntity.DateTime < DateTime.UtcNow.AddDays(-16))
            {
                await ChangeAndSaveAsync(session, _data, Constant.UserId.Anonymous);
            }
            else
            {
                session.ApplicationCultureName = sessionEntity.ApplicationCulture.ToCultureName();
                session.Digest = requestSessionIdBytes;
                session.Id = sessionEntity.Id;
                session.UserId = sessionEntity.UserId;
            }
        }
    }
}