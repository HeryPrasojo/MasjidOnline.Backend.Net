using MasjidOnline.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Api.Web;

public static class WebApplicationExtensions
{
    public static WebApplication MapEndpoint(this WebApplication webApplication)
    {
        var donationGroup = webApplication.MapGroup("/donation");

        donationGroup.MapPost("/donate", DonationEndPoint.Donate);


        var userGroup = webApplication.MapGroup("/user");

        userGroup.MapPost("/login", UserEndPoint.Login);


        return webApplication;
    }
}
