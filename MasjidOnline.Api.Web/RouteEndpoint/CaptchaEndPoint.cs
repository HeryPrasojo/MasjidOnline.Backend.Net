using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Business.Captcha.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

public static class CaptchaEndPoint
{
    public static async Task<IResult> CreateQuestionAsync(HttpContext httpContext, ICaptchaQuestionBusiness captchaQuestionBusiness)
    {
        var sessionId = httpContext.Request.Cookies[Constant.AnonymousSessionIdName];

        var createResponse = await captchaQuestionBusiness.CreateAsync(sessionId);

        if (createResponse.ResultCode != ResponseResult.Success) return default!;


        if (sessionId == default)
        {
            httpContext.Response.Cookies.Append(Constant.AnonymousSessionIdName, createResponse.SessionId!);
        }

        return Results.Stream(createResponse.Stream!, "image/png");
    }
}
