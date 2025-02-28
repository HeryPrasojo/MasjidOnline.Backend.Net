using MasjidOnline.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web;

internal static class WebApplicationExtension
{
    internal static WebApplication MapEndpoints(this WebApplication webApplication)
    {
        var captchaGroup = webApplication.MapGroup("/captcha");

        captchaGroup.MapPost("/question", CaptchaEndPoint.AddQuestionAsync);
        captchaGroup.MapPost("/answer", CaptchaEndPoint.AddAnswerAsync);


        var infaqGroup = webApplication.MapGroup("/infaq");

        infaqGroup.MapPost("/add/anonym", InfaqEndPoint.AddAnonymAsync);
        infaqGroup.MapPost("/getMany", InfaqEndPoint.GetManyAsync);
        infaqGroup.MapPost("/getMany/due", InfaqEndPoint.GetManyDueAsync);
        infaqGroup.MapPost("/getOne", InfaqEndPoint.GetOneAsync);

        infaqGroup.MapPost("/expired/add", InfaqEndPoint.AddExpiredAsync);


        var userGroup = webApplication.MapGroup("/user");

        userGroup.MapPost("/add/internal", UserEndPoint.AddInternalAsync);
        userGroup.MapPost("/login", UserEndPoint.LoginAsync);
        userGroup.MapPost("/setPassword", UserEndPoint.SetPasswordAsync);


        return webApplication;
    }
}
