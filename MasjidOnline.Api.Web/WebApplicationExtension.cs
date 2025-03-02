using MasjidOnline.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web;

internal static class WebApplicationExtension
{
    internal static WebApplication MapEndpoints(this WebApplication webApplication)
    {
        var captchaGroup = webApplication.MapGroup("/captcha/");

        captchaGroup.MapPost("question", CaptchaEndPoint.AddQuestionAsync);
        captchaGroup.MapPost("answer", CaptchaEndPoint.AddAnswerAsync);


        var infaqGroup = webApplication.MapGroup("/infaq/");

        var infaqInfaqGroup = infaqGroup.MapGroup("infaq/");

        infaqInfaqGroup.MapPost("add/anonym", InfaqEndPoint.Infaq.AddAnonymAsync);
        infaqInfaqGroup.MapPost("getMany", InfaqEndPoint.Infaq.GetManyAsync);
        infaqInfaqGroup.MapPost("getOne", InfaqEndPoint.Infaq.GetOneAsync);
        infaqInfaqGroup.MapPost("due/getMany", InfaqEndPoint.Infaq.GetManyDueAsync);
        infaqInfaqGroup.MapPost("due/getOne", InfaqEndPoint.Infaq.GetOneDueAsync);


        var infaqExpiredGroup = infaqGroup.MapGroup("expired/");

        infaqExpiredGroup.MapPost("add", InfaqEndPoint.Expired.AddExpiredAsync);


        var userGroup = webApplication.MapGroup("/user/");

        var userInternalGroup = userGroup.MapGroup("internal/");

        userInternalGroup.MapPost("add", UserEndPoint.Internal.AddAsync);


        var userUserGroup = userGroup.MapGroup("user/");

        userGroup.MapPost("login", UserEndPoint.User.LoginAsync);
        userGroup.MapPost("setPassword", UserEndPoint.User.SetPasswordAsync);


        return webApplication;
    }
}
