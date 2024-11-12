using Microsoft.AspNetCore.Builder;

namespace MasjidOnline.Backend.Net.Api.Web;

public static class WebApplicationExtensions
{
    public static void MapEndpoint(this WebApplication webApplication)
    {
        webApplication.MapPost("/public/login");
    }
}
