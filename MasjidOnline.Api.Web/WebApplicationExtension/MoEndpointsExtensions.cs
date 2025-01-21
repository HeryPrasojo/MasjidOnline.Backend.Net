using MasjidOnline.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web.WebApplicationExtension;

// todo rename to WebApplicationExtension, and move to MasjidOnline.Api.Web.
internal static class MoEndpointsExtensions
{
    internal static WebApplication MapEndpoints(this WebApplication webApplication)
    {
        var captchaGroup = webApplication.MapGroup("/captcha");

        captchaGroup.MapPost("/createQuestion", CaptchaEndPoint.CreateQuestionAsync);
        captchaGroup.MapPost("/answerQuestion", CaptchaEndPoint.AnswerQuestionAsync);


        var infaqGroup = webApplication.MapGroup("/infaq");

        infaqGroup.MapPost("/anonym/infaq", InfaqEndPoint.AnonymInfaqAsync);


        var userGroup = webApplication.MapGroup("/user");

        userGroup.MapPost("/login", UserEndPoint.LoginAsync);


        return webApplication;
    }
}
