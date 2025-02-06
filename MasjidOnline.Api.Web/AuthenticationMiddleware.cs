using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using MasjidOnline.Service.Hash512.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web;

public class AuthenticationMiddleware(
    RequestDelegate _nextRequestDelegate,
    IFieldValidatorService _fieldValidatorService,
    IHash512Service _hash512Service)
{
    public async Task Invoke(HttpContext httpContext, ISessionsData _sessionsData, Session session)
    {
        var requestSessionIdBase64 = httpContext.Request.Cookies[Constant.HttpCookieSessionName];

        if (requestSessionIdBase64 == default)
        {
            await CreateAnonymousSession(_sessionsData, session);
        }
        else
        {
            var requestSessionIdBytes = _fieldValidatorService.ValidateRequiredBase64(requestSessionIdBase64, 80, Constant.HttpCookieSessionName);


            var sessionEntity = await _sessionsData.Session.GetForAuthenticationAsync(requestSessionIdBytes);

            if (sessionEntity == default) throw new InputMismatchException(Constant.HttpCookieSessionName);

            if (sessionEntity.DateTime < DateTime.UtcNow.AddDays(-16))
            {
                await CreateAnonymousSession(_sessionsData, session, previousId: requestSessionIdBytes);
            }
            else
            {
                session.Id = sessionEntity.Id;
                session.UserId = sessionEntity.UserId;
            }
        }

        httpContext.Response.OnStarting(() =>
        {
            if (session.NewId != default)
            {
                var responseSessionIdBase64 = Convert.ToBase64String(session.NewId);

                httpContext.Response.Cookies.Append(Constant.HttpCookieSessionName, responseSessionIdBase64);
            }

            return Task.CompletedTask;
        });

        await _nextRequestDelegate(httpContext);
    }

    private async Task CreateAnonymousSession(ISessionsData sessionsData, Session session, byte[]? previousId = default)
    {
        session.Id = _hash512Service.RandomDigestBytes;
        session.UserId = Business.Interface.Model.Constant.AnonymousUserId;
        session.NewId = session.Id;


        var sessionEntity = new Entity.Sessions.Session
        {
            DateTime = DateTime.UtcNow,
            Id = session.Id,
            PreviousId = previousId,
            UserId = session.UserId,
        };

        await sessionsData.Session.AddAndSaveAsync(sessionEntity);
    }
}
