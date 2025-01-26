using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Captcha.Interface.Model;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class CaptchaEndPoint
{
    internal static async Task<IResult> CreateQuestionAsync(HttpContext httpContext, IQuestionBusiness captchaQuestionBusiness)
    {
        var sessionIdBase64 = httpContext.Request.Cookies[Constant.HttpCookieSessionName];

        var sessionId = sessionIdBase64 == default ? default : Convert.FromBase64String(sessionIdBase64!);


        var createResponse = await captchaQuestionBusiness.CreateAsync(sessionId);

        httpContext.Response.Headers[Constant.HttpHeaderName.ResultCode] = createResponse.ResultCode.ToString();
        httpContext.Response.Headers[Constant.HttpHeaderName.ResultMessage] = createResponse.ResultMessage;

        if (createResponse.ResultCode != ResponseResult.Success) return Results.Empty;


        if (sessionId == default)
        {
            sessionIdBase64 = Convert.ToBase64String(createResponse.SessionId!);

            httpContext.Response.Cookies.Append(Constant.HttpCookieSessionName, sessionIdBase64);
        }

        return Results.Stream(createResponse.Stream!, "image/png");
    }

    internal static async Task<AnswerQuestionResponse> AnswerQuestionAsync(
        HttpContext httpContext,
        IAnswerBusiness captchaAnswerBusiness,
        AnswerQuestionRequest answerQuestionRequest)
    {
        var sessionIdBase64 = httpContext.Request.Cookies[Constant.HttpCookieSessionName];

        var sessionId = sessionIdBase64 == default ? default : Convert.FromBase64String(sessionIdBase64!);

        return await captchaAnswerBusiness.AnswerAsync(sessionId, answerQuestionRequest);
    }
}
