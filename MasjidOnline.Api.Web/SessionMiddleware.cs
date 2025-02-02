using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using MasjidOnline.Service.Hash512.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web;

public class SessionMiddleware(
    RequestDelegate _nextRequestDelegate,
    IFieldValidatorService _fieldValidatorService,
    IHash512Service _hash512Service)
{
    public async Task Invoke(HttpContext httpContext, ISessionsData sessionsData, Session session)
    {
        var requestSessionIdBase64 = httpContext.Request.Cookies[Web.Constant.HttpCookieSessionName];

        if (requestSessionIdBase64 == default)
        {
            await CreateAnonymousSession(sessionsData, session);
        }
        else
        {
            var requestSessionIdBytes = _fieldValidatorService.ValidateRequiredBase64(requestSessionIdBase64, 80, Web.Constant.HttpCookieSessionName);


            var sessionEntity = await sessionsData.Session.GetFirstByIdAsync(requestSessionIdBytes);

            if (sessionEntity == default) throw new InputMismatchException(Web.Constant.HttpCookieSessionName);

            if (sessionEntity.DateTime < DateTime.UtcNow.AddDays(-16))
            {
                await CreateAnonymousSession(sessionsData, session);

                requestSessionIdBase64 = default;
            }
            else
            {
                session.Id = sessionEntity.Id;
                session.UserId = sessionEntity.UserId;
            }
        }

        await _nextRequestDelegate(httpContext);

        if (requestSessionIdBase64 == default)
        {
            requestSessionIdBase64 = Convert.ToBase64String(session.Id);

            httpContext.Response.Cookies.Append(Web.Constant.HttpCookieSessionName, requestSessionIdBase64);
        }
    }

    private async Task CreateAnonymousSession(ISessionsData sessionsData, Session session, byte[]? previousId = default)
    {
        session.Id = _hash512Service.RandomDigestBytes;
        session.UserId = Business.Interface.Model.Constant.AnonymousUserId;


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
