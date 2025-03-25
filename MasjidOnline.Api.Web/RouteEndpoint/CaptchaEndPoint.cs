using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class CaptchaEndPoint
{
    internal static async Task<IResult> AddQuestionAsync(
        HttpContext httpContext,
        ICaptchaAddBusiness _captchaAddBusiness,
        ISessionBusiness _sessionBusiness,
        IData _data)
    {
        var createResponse = await _captchaAddBusiness.AddAsync(_data, _sessionBusiness);

        httpContext.Response.Headers[Constant.HttpHeaderName.ResultCode] = createResponse.ResultCode.ToString();
        httpContext.Response.Headers[Constant.HttpHeaderName.ResultMessage] = createResponse.ResultMessage;

        if (createResponse.ResultCode != ResponseResultCode.Success) return Results.Empty;

        return Results.Stream(createResponse.Stream!, "image/png");
    }

    internal static async Task<Response> UpdateAsync(
        ICaptchaUpdateBusiness _captchaUpdateBusiness,
        IData _data,
        ISessionBusiness _sessionBusiness,
        CaptchaUpdateRequest captchaUpdateRequest)
    {
        return await _captchaUpdateBusiness.UpdateAsync(_data, _sessionBusiness, captchaUpdateRequest);
    }
}
