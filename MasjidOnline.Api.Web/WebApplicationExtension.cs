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

        infaqGroup.MapPost("/add/anonym", InfaqEndPoint.Infaq.AddAnonymAsync);
        infaqGroup.MapPost("/getMany", InfaqEndPoint.Infaq.GetManyAsync);
        infaqGroup.MapPost("/getMany/due", InfaqEndPoint.Infaq.GetManyDueAsync);
        infaqGroup.MapPost("/getOne", InfaqEndPoint.Infaq.GetOneAsync);
        infaqGroup.MapPost("/getOne/due", InfaqEndPoint.Infaq.GetOneDueAsync);

        infaqGroup.MapPost("/expired/add", InfaqEndPoint.Expired.AddExpiredAsync);


        var userGroup = webApplication.MapGroup("/user");

        userGroup.MapPost("/add/internal", UserEndPoint.AddInternalAsync);
        userGroup.MapPost("/login", UserEndPoint.LoginAsync);
        userGroup.MapPost("/setPassword", UserEndPoint.SetPasswordAsync);


        return webApplication;
    }
}
