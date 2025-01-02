using MasjidOnline.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web;

internal static class WebApplicationExtensions
{
    internal static WebApplication MapEndpoint(this WebApplication webApplication)
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
