using System;
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
        var anonymousSessionId = httpContext.Request.Cookies[Constant.AnonymousSessionIdName];

        var createResponse = await captchaQuestionBusiness.CreateAsync(anonymousSessionId);

        httpContext.Response.Headers["Mo-Captcha-Result-Code"] = createResponse.ResultCode.ToString();
        httpContext.Response.Headers["Mo-Captcha-Result-Message"] = createResponse.ResultMessage;

        if (createResponse.ResultCode != ResponseResult.Success) return default!;


        if (anonymousSessionId == default)
        {
            httpContext.Response.Cookies.Append(Constant.AnonymousSessionIdName, createResponse.SessionId!);
        }

        return Results.Stream(createResponse.Stream!, "image/png");
    }

    internal static async Task AnswerQuestionAsync(
        HttpContext httpContext,
        ICaptchaQuestionBusiness captchaQuestionBusiness,
        AnswerQuestionRequest answerQuestionRequest)
    {
        throw new NotImplementedException();
    }
}
