using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class CaptchaEndPoint
{
    internal static async Task<IResult> CreateQuestionAsync(
        HttpContext httpContext,
        IQuestionBusiness captchaQuestionBusiness,
        ISessionBusiness _sessionBusiness,
        ICaptchaData _captchaData)
    {
        var createResponse = await captchaQuestionBusiness.CreateAsync(_captchaData, _sessionBusiness);

        httpContext.Response.Headers[Constant.HttpHeaderName.ResultCode] = createResponse.ResultCode.ToString();
        httpContext.Response.Headers[Constant.HttpHeaderName.ResultMessage] = createResponse.ResultMessage;

        if (createResponse.ResultCode != ResponseResult.Success) return Results.Empty;

        return Results.Stream(createResponse.Stream!, "image/png");
    }

    internal static async Task<Response> AnswerQuestionAsync(
        IAnswerBusiness captchaAnswerBusiness,
        ICaptchaData _captchaData,
        ISessionBusiness _sessionBusiness,
        AnswerQuestionRequest answerQuestionRequest)
    {
        return await captchaAnswerBusiness.AnswerAsync(_captchaData, _sessionBusiness, answerQuestionRequest);
    }
}
