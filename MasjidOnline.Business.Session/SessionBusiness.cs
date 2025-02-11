using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Session;

public class SessionBusiness(
    IFieldValidatorService _fieldValidatorService,
    ISessionsData _sessionsData,
    ISessionsIdGenerator _sessionsIdGenerator) : ISessionBusiness
{
    private byte[]? digest;

    public int Id { get; private set; }
    public string DigestBase64 => digest == default ? throw new ErrorException(nameof(digest)) : Convert.ToBase64String(digest);
    public bool IsDigestNew { get; private set; }
    public int UserId { get; private set; }

    public async Task ChangeAsync(int userId)
    {
        var previousId = digest;

        var session = new Entity.Sessions.Session
        {
            DateTime = DateTime.UtcNow,
            Digest = _sessionsIdGenerator.SessionDigest,
            Id = _sessionsIdGenerator.SessionId,
            PreviousId = previousId,
            UserId = UserId,
        };

        await _sessionsData.Session.AddAndSaveAsync(session);


        digest = session.Digest;
        Id = session.Id;
        IsDigestNew = true;
        UserId = session.UserId;
    }

    public async Task StartAsync(string? idBase64, [CallerArgumentExpression(nameof(idBase64))] string? idBase64Expression = default)
    {
        if (idBase64 == default)
        {
            await ChangeAsync(Constant.AnonymousUserId);
        }
        else
        {
            var requestSessionIdBytes = _fieldValidatorService.ValidateRequiredBase64(idBase64, 80, idBase64Expression);


            var sessionEntity = await _sessionsData.Session.GetForAuthenticationAsync(requestSessionIdBytes);

            if (sessionEntity == default) throw new InputMismatchException(idBase64Expression);

            if (sessionEntity.DateTime < DateTime.UtcNow.AddDays(-16))
            {
                await ChangeAsync(Constant.AnonymousUserId);
            }
            else
            {
                digest = sessionEntity.Id;
                UserId = sessionEntity.UserId;
            }
        }
    }
}