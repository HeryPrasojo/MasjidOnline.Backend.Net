using MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web.WebApplicationExtension;

internal static class MapEndpointsExtension
{
    internal static WebApplication MapEndpoints(this WebApplication webApplication)
    {
        var captchaGroup = webApplication.MapGroup("/captcha/").DisableAntiforgery();

        captchaGroup.MapPost("getStatus", CaptchaEndpoint.Pass.GetStatusAsync);


        var infaqGroup = webApplication.MapGroup("/infaq/").DisableAntiforgery();

        var infaqInfaqGroup = infaqGroup.MapGroup("infaq/");

        infaqInfaqGroup.MapPost("add/anonym", InfaqEndpoint.Infaq.AddAnonymAsync);
        infaqInfaqGroup.MapPost("getMany", InfaqEndpoint.Infaq.GetManyAsync);
        infaqInfaqGroup.MapPost("getOne", InfaqEndpoint.Infaq.GetOneAsync);


        var infaqExpireGroup = infaqGroup.MapGroup("expire/");

        infaqExpireGroup.MapPost("add", InfaqEndpoint.Expire.AddAsync);
        infaqExpireGroup.MapPost("approve", InfaqEndpoint.Expire.ApproveAsync);
        infaqExpireGroup.MapPost("cancel", InfaqEndpoint.Expire.CancelAsync);
        infaqExpireGroup.MapPost("getMany", InfaqEndpoint.Expire.GetManyAsync);
        infaqExpireGroup.MapPost("getOne", InfaqEndpoint.Expire.GetOneAsync);
        infaqExpireGroup.MapPost("reject", InfaqEndpoint.Expire.RejectAsync);


        var infaqSuccessGroup = infaqGroup.MapGroup("success/");

        infaqSuccessGroup.MapPost("add", InfaqEndpoint.Success.AddAsync);
        infaqSuccessGroup.MapPost("approve", InfaqEndpoint.Success.ApproveAsync);
        infaqSuccessGroup.MapPost("cancel", InfaqEndpoint.Success.CancelAsync);
        infaqSuccessGroup.MapPost("getMany", InfaqEndpoint.Success.GetManyAsync);
        infaqSuccessGroup.MapPost("getOne", InfaqEndpoint.Success.GetOneAsync);
        infaqSuccessGroup.MapPost("reject", InfaqEndpoint.Success.RejectAsync);


        var infaqVoidGroup = infaqGroup.MapGroup("void/");

        infaqVoidGroup.MapPost("add", InfaqEndpoint.Void.AddAsync);
        infaqVoidGroup.MapPost("approve", InfaqEndpoint.Void.ApproveAsync);
        infaqVoidGroup.MapPost("cancel", InfaqEndpoint.Void.CancelAsync);
        infaqVoidGroup.MapPost("getMany", InfaqEndpoint.Void.GetManyAsync);
        infaqVoidGroup.MapPost("getOne", InfaqEndpoint.Void.GetOneAsync);
        infaqVoidGroup.MapPost("reject", InfaqEndpoint.Void.RejectAsync);


        var userGroup = webApplication.MapGroup("/user/").DisableAntiforgery();

        var userInternalGroup = userGroup.MapGroup("internal/");

        userInternalGroup.MapPost("add", UserEndpoint.Internal.AddAsync);
        userInternalGroup.MapPost("approve", UserEndpoint.Internal.ApproveAsync);
        userInternalGroup.MapPost("cancel", UserEndpoint.Internal.CancelAsync);
        userInternalGroup.MapPost("getMany", UserEndpoint.Internal.GetManyAsync);
        userInternalGroup.MapPost("getOne", UserEndpoint.Internal.GetOneAsync);
        userInternalGroup.MapPost("reject", UserEndpoint.Internal.RejectAsync);


        var userUserGroup = userGroup.MapGroup("user/");

        // todo change path
        userUserGroup.MapPost("login", UserEndpoint.User.LoginAsync);
        userUserGroup.MapPost("setPassword", UserEndpoint.User.SetPasswordAsync);


        var sessionGroup = webApplication.MapGroup("session/");

        sessionGroup.MapPost("create", SessionEndpoint.Create).DisableAntiforgery();

        return webApplication;
    }
}
