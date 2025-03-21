using MasjidOnline.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web;

internal static class WebApplicationExtension
{
    internal static WebApplication MapEndpoints(this WebApplication webApplication)
    {
        var captchaGroup = webApplication.MapGroup("/captcha/");

        captchaGroup.MapPost("question", CaptchaEndPoint.AddQuestionAsync);
        captchaGroup.MapPost("answer", CaptchaEndPoint.UpdateAsync);


        var infaqGroup = webApplication.MapGroup("/infaq/");

        var infaqInfaqGroup = infaqGroup.MapGroup("infaq/");

        infaqInfaqGroup.MapPost("add/anonym", InfaqEndPoint.Infaq.AddAnonymAsync);
        infaqInfaqGroup.MapPost("getMany", InfaqEndPoint.Infaq.GetManyAsync);
        infaqInfaqGroup.MapPost("getMany/due", InfaqEndPoint.Infaq.GetManyDueAsync);
        infaqInfaqGroup.MapPost("getOne", InfaqEndPoint.Infaq.GetOneAsync);
        infaqInfaqGroup.MapPost("getOne/due", InfaqEndPoint.Infaq.GetOneDueAsync);


        var infaqExpireGroup = infaqGroup.MapGroup("expire/");

        infaqExpireGroup.MapPost("add", InfaqEndPoint.Expire.AddAsync);
        infaqExpireGroup.MapPost("approve", InfaqEndPoint.Expire.ApproveAsync);
        infaqExpireGroup.MapPost("cancel", InfaqEndPoint.Expire.CancelAsync);
        infaqExpireGroup.MapPost("getMany", InfaqEndPoint.Expire.GetManyAsync);
        infaqExpireGroup.MapPost("getMany/new", InfaqEndPoint.Expire.GetManyNewAsync);
        infaqExpireGroup.MapPost("getOne", InfaqEndPoint.Expire.GetOneAsync);
        infaqExpireGroup.MapPost("getOne/new", InfaqEndPoint.Expire.GetOneNewAsync);
        infaqExpireGroup.MapPost("reject", InfaqEndPoint.Expire.RejectAsync);


        var infaqSuccessGroup = infaqGroup.MapGroup("success/");

        infaqSuccessGroup.MapPost("add", InfaqEndPoint.Success.AddAsync);
        infaqSuccessGroup.MapPost("approve", InfaqEndPoint.Success.ApproveAsync);
        infaqSuccessGroup.MapPost("cancel", InfaqEndPoint.Success.CancelAsync);
        infaqSuccessGroup.MapPost("getMany", InfaqEndPoint.Success.GetManyAsync);
        infaqSuccessGroup.MapPost("getMany/new", InfaqEndPoint.Success.GetManyNewAsync);
        infaqSuccessGroup.MapPost("getOne", InfaqEndPoint.Success.GetOneAsync);
        infaqSuccessGroup.MapPost("getOne/new", InfaqEndPoint.Success.GetOneNewAsync);
        infaqSuccessGroup.MapPost("reject", InfaqEndPoint.Success.RejectAsync);


        var infaqVoidGroup = infaqGroup.MapGroup("void/");

        infaqVoidGroup.MapPost("add", InfaqEndPoint.Void.AddAsync);
        infaqVoidGroup.MapPost("approve", InfaqEndPoint.Void.ApproveAsync);
        infaqVoidGroup.MapPost("cancel", InfaqEndPoint.Void.CancelAsync);
        infaqVoidGroup.MapPost("getMany", InfaqEndPoint.Void.GetManyAsync);
        infaqVoidGroup.MapPost("getMany/new", InfaqEndPoint.Void.GetManyNewAsync);
        infaqVoidGroup.MapPost("getOne", InfaqEndPoint.Void.GetOneAsync);
        infaqVoidGroup.MapPost("getOne/new", InfaqEndPoint.Void.GetOneNewAsync);
        infaqVoidGroup.MapPost("reject", InfaqEndPoint.Void.RejectAsync);


        var userGroup = webApplication.MapGroup("/user/");

        var userInternalGroup = userGroup.MapGroup("internal/");

        userInternalGroup.MapPost("add", UserEndPoint.Internal.AddAsync);
        userInternalGroup.MapPost("approve", UserEndPoint.Internal.ApproveAsync);
        userInternalGroup.MapPost("cancel", UserEndPoint.Internal.CancelAsync);
        userInternalGroup.MapPost("getMany", UserEndPoint.Internal.GetManyAsync);
        userInternalGroup.MapPost("getMany/new", UserEndPoint.Internal.GetManyNewAsync);
        userInternalGroup.MapPost("getOne", UserEndPoint.Internal.GetOneAsync);
        userInternalGroup.MapPost("getOne/new", UserEndPoint.Internal.GetOneNewAsync);
        userInternalGroup.MapPost("reject", UserEndPoint.Internal.RejectAsync);


        var userUserGroup = userGroup.MapGroup("user/");

        // todo change path
        userGroup.MapPost("login", UserEndPoint.User.LoginAsync);
        userGroup.MapPost("setPassword", UserEndPoint.User.SetPasswordAsync);


        return webApplication;
    }
}
