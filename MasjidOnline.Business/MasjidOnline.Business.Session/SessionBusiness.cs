using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

// hack change to singleton, move scoped to new class.
public class SessionBusiness(IService _service, IIdGenerator _idGenerator) : ISessionBusiness
{
    private Memory<byte> _digest = Memory<byte>.Empty;


    public int Id { get; private set; }

    public bool IsUserAnonymous => UserId == Constant.UserId.Anonymous;

    public int UserId { get; private set; }

    public async Task ChangeAsync(IData _data, int userId)
    {
        var session = new Entity.Session.Session
        {
            DateTime = DateTime.UtcNow,
            Digest = _idGenerator.Session.SessionDigest,
            Id = _idGenerator.Session.SessionId,
            PreviousId = _digest.ToArray(),
            UserId = userId,
        };

        await _data.Session.Session.AddAsync(session);


        _digest = session.Digest;
        Id = session.Id;
        UserId = session.UserId;
    }

    public async Task ChangeAndSaveAsync(IData _data, int userId)
    {
        await ChangeAsync(_data, userId);

        await _data.Session.SaveAsync();
    }

    public string GetDigestBase64(Interface.Session session)
    {
        var encryptedDigest = _service.Encryption128128.Encrypt(session.Digest.Span);

        return Convert.ToBase64String(encryptedDigest);
    }

    public async Task StartAsync(IData _data, string? idBase64, [CallerArgumentExpression(nameof(idBase64))] string? idBase64Expression = default)
    {
        if (idBase64 == default)
        {
            await ChangeAndSaveAsync(_data, Constant.UserId.Anonymous);
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
            else
            {
                _digest = requestSessionIdBytes;
                Id = sessionEntity.Id;
                UserId = sessionEntity.UserId;
            }
        }
    }
}