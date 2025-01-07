using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class CaptchaEndPoint
{
    internal static async Task<IResult> CreateQuestionAsync(HttpContext httpContext, ICaptchaQuestionBusiness captchaQuestionBusiness)
    {
        var sessionId = httpContext.Request.Cookies[Constant.HttpCookieSessionName];

        var createResponse = await captchaQuestionBusiness.CreateAsync(sessionId);

        httpContext.Response.Headers[Constant.HttpHeaderName.ResultCode] = createResponse.ResultCode.ToString();
        httpContext.Response.Headers[Constant.HttpHeaderName.ResultMessage] = createResponse.ResultMessage;

        if (createResponse.ResultCode != ResponseResult.Success) return default!;


        if (sessionId == default)
        {
            httpContext.Response.Cookies.Append(Constant.HttpCookieSessionName, createResponse.SessionId!);
        }

        return Results.Stream(createResponse.Stream!, "image/png");
    }

    internal static async Task AnswerQuestionAsync(
        HttpContext httpContext,
        ICaptchaAnswerBusiness captchaAnswerBusiness,
        AnswerQuestionRequest answerQuestionRequest)
    {
        //throw new NotImplementedException();
    }
}
