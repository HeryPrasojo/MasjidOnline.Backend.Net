using MasjidOnline.Backend.Api.Web.RouteEndpoint;
using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Backend.Api.Web;

public static class WebApplicationExtensions
{
    public static void MapEndpoint(this WebApplication webApplication)
    {
        var authenticationGroup = webApplication.MapGroup("/authentication");

        authenticationGroup.MapPost("/login", AuthenticationEndPoint.Login);
    }
}
