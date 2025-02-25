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

        infaqGroup.MapPost("/infaqByAnonym", InfaqEndPoint.AddByAnonymAsync);

        infaqGroup.MapPost("/getMany", InfaqEndPoint.GetManyAsync);
        infaqGroup.MapPost("/getOne", InfaqEndPoint.GetOneAsync);
        infaqGroup.MapPost("/setPaymentStatusExpire", InfaqEndPoint.);


        var userGroup = webApplication.MapGroup("/user");

        userGroup.MapPost("/add", UserEndPoint.Addsync);
        userGroup.MapPost("/login", UserEndPoint.LoginAsync);
        userGroup.MapPost("/setPassword", UserEndPoint.SetPasswordAsync);


        return webApplication;
    }
}
