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
    internal static async Task<IResult> AddQuestionAsync(
        HttpContext httpContext,
        ICaptchaQuestionBusiness _captchaQuestionBusiness,
        ISessionBusiness _sessionBusiness,
        ICaptchaData _captchaData)
    {
        var createResponse = await _captchaQuestionBusiness.AddAsync(_captchaData, _sessionBusiness);

        httpContext.Response.Headers[Constant.HttpHeaderName.ResultCode] = createResponse.ResultCode.ToString();
        httpContext.Response.Headers[Constant.HttpHeaderName.ResultMessage] = createResponse.ResultMessage;

        if (createResponse.ResultCode != ResponseResultCode.Success) return Results.Empty;

        return Results.Stream(createResponse.Stream!, "image/png");
    }

    internal static async Task<Response> AddAnswerAsync(
        ICaptchaAnswerBusiness _captchaAnswerBusiness,
        ICaptchaData _captchaData,
        ISessionBusiness _sessionBusiness,
        AnswerAddRequest answerAddRequest)
    {
        return await _captchaAnswerBusiness.AddAsync(_captchaData, _sessionBusiness, answerAddRequest);
    }
}
