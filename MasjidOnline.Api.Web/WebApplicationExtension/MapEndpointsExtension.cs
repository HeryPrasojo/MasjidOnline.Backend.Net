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
        expenditureGroup.MapPost("table", AccountancyEndpoint.Expenditure.GetTableAsync);
        expenditureGroup.MapPost("view", AccountancyEndpoint.Expenditure.GetViewAsync);
        expenditureGroup.MapPost("reject", AccountancyEndpoint.Expenditure.RejectAsync);


        var donationGroup = webApplication.MapGroup("/donation/")
            .DisableAntiforgery()
            .AddEndpointFilter(endpointFilter);

        var donationDonationGroup = donationGroup.MapGroup("donation/");

        donationDonationGroup.MapPost("add", DonationEndpoint.Donation.AddAsync);
        donationDonationGroup.MapPost("table", DonationEndpoint.Donation.GetTableAsync);
        donationDonationGroup.MapPost("view", DonationEndpoint.Donation.GetViewAsync);


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

        userInternalGroup.MapPost("table", UserEndpoint.Internal.GetTableAsync);
        userInternalGroup.MapPost("view", UserEndpoint.Internal.GetViewAsync);


        return webApplication;
    }
}


