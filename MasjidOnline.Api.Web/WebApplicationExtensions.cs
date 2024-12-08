﻿using MasjidOnline.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web;

public static class WebApplicationExtensions
{
    public static WebApplication MapEndpoint(this WebApplication webApplication)
    {
        var authenticationGroup = webApplication.MapGroup("/authentication");

        authenticationGroup.MapPost("/login", AuthenticationEndPoint.Login);

        return webApplication;
    }
}
