using MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;
using MasjidOnline.Library.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.WebApplicationExtension;

internal static class MapEndpointsExtension
{
    internal static WebApplication MapEndpoints(this WebApplication webApplication)
    {
        var endpointFilter = webApplication.Services.GetServiceOrThrow<IEndpointFilter>();


        var expenditureGroup = webApplication.MapGroup("/expenditure/")
            .DisableAntiforgery()
            .AddEndpointFilter(endpointFilter);

        expenditureGroup.MapPost("add", AccountancyEndpoint.Expenditure.AddAsync);
        expenditureGroup.MapPost("approve", AccountancyEndpoint.Expenditure.ApproveAsync);
        expenditureGroup.MapPost("cancel", AccountancyEndpoint.Expenditure.CancelAsync);
        expenditureGroup.MapPost("getMany", AccountancyEndpoint.Expenditure.GetManyAsync);
        expenditureGroup.MapPost("getOne", AccountancyEndpoint.Expenditure.GetOneAsync);
        expenditureGroup.MapPost("reject", AccountancyEndpoint.Expenditure.RejectAsync);


        var infaqGroup = webApplication.MapGroup("/infaq/")
            .DisableAntiforgery()
            .AddEndpointFilter(endpointFilter);

        var infaqInfaqGroup = infaqGroup.MapGroup("infaq/");

        infaqInfaqGroup.MapPost("add", InfaqEndpoint.Infaq.AddAsync);
        infaqInfaqGroup.MapPost("getMany", InfaqEndpoint.Infaq.GetManyAsync);
        infaqInfaqGroup.MapPost("getOne", InfaqEndpoint.Infaq.GetOneAsync);


        var paymentGroup = webApplication.MapGroup("/payment/")
            .DisableAntiforgery()
            .AddEndpointFilter(endpointFilter);

        var paymentManualGroup = paymentGroup.MapGroup("manual/");

        paymentManualGroup.MapPost("getRecommendationNote", PaymentEndpoint.Manual.GetRecommendationNoteAsync);


        var sessionSessionGroup = webApplication.MapGroup("session/")
            .DisableAntiforgery()
            .AddEndpointFilter(endpointFilter);

        sessionSessionGroup.MapPost("create", SessionEndpoint.Session.CreateAsync);


        var userGroup = webApplication.MapGroup("/user/")
            .DisableAntiforgery()
            .AddEndpointFilter(endpointFilter);

        userGroup.MapPost("login", UserEndpoint.User.LoginAsync);
        userGroup.MapPost("register", UserEndpoint.User.RegisterAsync);
        userGroup.MapPost("verifyRegister", UserEndpoint.User.VerifyRegisterAsync);
        userGroup.MapPost("verifySetPassword", UserEndpoint.User.VerifySetPasswordAsync);


        var userInternalGroup = userGroup.MapGroup("internal/");

        userInternalGroup.MapPost("getMany", UserEndpoint.Internal.GetManyAsync);
        userInternalGroup.MapPost("getOne", UserEndpoint.Internal.GetOneAsync);


        return webApplication;
    }
}
