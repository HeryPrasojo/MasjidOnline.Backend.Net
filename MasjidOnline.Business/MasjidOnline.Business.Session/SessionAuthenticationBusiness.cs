using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionAuthenticationBusiness(IService _service) : ISessionAuthenticationBusiness
{
    public async Task AuthenticateAsync(
        Interface.Model.Session session,
        IData _data,
        string? codeBase64,
        [CallerArgumentExpression(nameof(codeBase64))] string? codeBase64Expression = default)
    {
        if (codeBase64 == default) return;


        var requestSessionIdBytes = _service.FieldValidator.ValidateRequiredBase64(codeBase64, 64 + _service.Encryption256kService.OverHeadSize, codeBase64Expression);

        var decryptedRquestSessionIdBytes = _service.Encryption256k128bService.Decrypt(requestSessionIdBytes);

        if (decryptedRquestSessionIdBytes == default) return;


        var sessionEntity = await _data.Session.Session.GetForStartAsync(decryptedRquestSessionIdBytes);

        if (sessionEntity == default)
        {
            // hack log event

            throw new SessionExpireException(default);
        }


        session.Id = sessionEntity.Id;
        session.UserId = sessionEntity.UserId;
        session.CultureInfo = Mapper.Mapper.Session.UserPreferenceApplicationCulture[sessionEntity.ApplicationCulture];

        await _data.Session.Session.SetForAuthenticateAsync(session.Id, DateTime.UtcNow);
    }
}