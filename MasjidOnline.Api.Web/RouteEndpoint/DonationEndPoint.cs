﻿using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Donation;
using MasjidOnline.Business.Donation.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class DonationEndPoint
{
    internal static async Task<AnonymDonateResponse> AnonymDonateAsync(
        HttpContext httpContext,
        IAnonymDonateBusiness anonymDonateBusiness,
        AnonymDonateRequest anonymDonateRequest)
    {
        var sessionId = httpContext.Request.Cookies[Constant.HttpCookieSessionName.AnonymousId];

        var anonymDonateResponse = await anonymDonateBusiness.DonateAsync(sessionId, anonymDonateRequest);

        if (sessionId == default)
        {
            httpContext.Response.Cookies.Append(Constant.HttpCookieSessionName.AnonymousId, anonymDonateResponse.SessionId!);
        }

        anonymDonateResponse.SessionId = default;

        return anonymDonateResponse;
    }
}
