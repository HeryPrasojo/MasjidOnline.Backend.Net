using MasjidOnline.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web.WebApplicationExtension;

internal static class MoEndpointsExtensions
{
    internal static WebApplication MapEndpoints(this WebApplication webApplication)
    {
        var captchaGroup = webApplication.MapGroup("/captcha");

        captchaGroup.MapPost("/createQuestion", CaptchaEndPoint.CreateQuestionAsync);
        captchaGroup.MapPost("/answerQuestion", CaptchaEndPoint.AnswerQuestionAsync);


        var donationGroup = webApplication.MapGroup("/donation");

        donationGroup.MapPost("/anonym/donate", DonationEndPoint.AnonymDonateAsync);


        var userGroup = webApplication.MapGroup("/user");

        userGroup.MapPost("/login", UserEndPoint.LoginAsync);


        return webApplication;
    }
}
