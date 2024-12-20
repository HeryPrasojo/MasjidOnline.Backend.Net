﻿using MasjidOnline.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web;

public static class WebApplicationExtensions
{
    public static WebApplication MapEndpoint(this WebApplication webApplication)
    {
        var captchaGroup = webApplication.MapGroup("/captcha");

        captchaGroup.MapPost("/create", CaptchaEndPoint.CreateAsync);


        var donationGroup = webApplication.MapGroup("/donation");

        donationGroup.MapPost("/anonym/donate", DonationEndPoint.AnonymDonateAsync);


        var userGroup = webApplication.MapGroup("/user");

        userGroup.MapPost("/login", UserEndPoint.LoginAsync);


        return webApplication;
    }
}
