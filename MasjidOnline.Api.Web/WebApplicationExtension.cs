using MasjidOnline.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web;

internal static class WebApplicationExtension
{
    internal static WebApplication MapEndpoints(this WebApplication webApplication)
    {
        var captchaGroup = webApplication.MapGroup("/captcha");

        captchaGroup.MapPost("/createQuestion", CaptchaEndPoint.CreateQuestionAsync);
        captchaGroup.MapPost("/answerQuestion", CaptchaEndPoint.AnswerQuestionAsync);


        var infaqGroup = webApplication.MapGroup("/infaq");

        infaqGroup.MapPost("/anonym/infaq", InfaqEndPoint.AnonymInfaqAsync);


        var userGroup = webApplication.MapGroup("/user");

        userGroup.MapPost("/add", UserEndPoint.Addsync);
        userGroup.MapPost("/login", UserEndPoint.LoginAsync);


        return webApplication;
    }
}
