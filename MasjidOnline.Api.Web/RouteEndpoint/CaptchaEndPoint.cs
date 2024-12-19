using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

public class CaptchaEndPoint
{
    public static async Task<IResult> CreateAsync(HttpContext httpContext, ICaptchaBusiness captchaBusiness)
    {
        var sessionId = httpContext.Request.Cookies["sessionId"];

        var createResponse = await captchaBusiness.CreateAsync(sessionId);

        if (createResponse.Result != ResponseResult.Success) return default!;


        if (sessionId == default)
        {
            httpContext.Response.Cookies.Append("sessionId", createResponse.SessionId!);
        }

        return Results.Stream(createResponse.Stream!, "image/png");
    }
}
