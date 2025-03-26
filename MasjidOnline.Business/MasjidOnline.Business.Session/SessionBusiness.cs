using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Cryptography.Interface;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Session;

public class SessionBusiness(
    IEncryption128128 _encryption128128,
    IFieldValidatorService _fieldValidatorService,
    IData _data,
    ISessionIdGenerator _sessionIdGenerator) : ISessionBusiness
{
    private Memory<byte> _digest = Memory<byte>.Empty;

    public int Id { get; private set; }
    public string DigestBase64
    {
        get
        {
            if (_digest.IsEmpty) throw new ErrorException(nameof(_digest));

            var encryptedDigest = _encryption128128.Encrypt(_digest.Span);

            return Convert.ToBase64String(encryptedDigest);
        }
    }

    public bool IsDigestNew { get; private set; }
    public int UserId { get; private set; }

    public async Task ChangeAsync(int userId)
    {
        var session = new Entity.Session.Session
        {
            DateTime = DateTime.UtcNow,
            Digest = _sessionIdGenerator.SessionDigest,
            Id = _sessionIdGenerator.SessionId,
            PreviousId = _digest.ToArray(),
            UserId = userId,
        };

        await _data.Session.Session.AddAsync(session);


        _digest = session.Digest;
        Id = session.Id;
        IsDigestNew = true;
        UserId = session.UserId;
    }

    public async Task ChangeAndSaveAsync(int userId)
    {
        await ChangeAsync(userId);

        await _data.Session.SaveAsync();
    }

    public async Task StartAsync(string? idBase64, [CallerArgumentExpression(nameof(idBase64))] string? idBase64Expression = default)
    {
        if (idBase64 == default)
        {
            await ChangeAndSaveAsync(Constant.UserId.Anonymous);
        }
        else
        {
            var requestSessionIdBytes = _fieldValidatorService.ValidateRequiredBase64(idBase64, 108, idBase64Expression);

            var decryptedRquestSessionIdBytes = _encryption128128.Decrypt(requestSessionIdBytes);

            var sessionEntity = await _data.Session.Session.GetForStartAsync(decryptedRquestSessionIdBytes);

            if (sessionEntity == default) throw new InputMismatchException(idBase64Expression);


            if (sessionEntity.DateTime < DateTime.UtcNow.AddDays(-16))
            {
                await ChangeAndSaveAsync(Constant.UserId.Anonymous);
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