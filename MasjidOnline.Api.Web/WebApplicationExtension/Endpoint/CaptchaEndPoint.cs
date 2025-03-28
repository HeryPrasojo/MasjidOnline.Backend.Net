using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class CaptchaEndPoint
{
    internal static async Task<IResult> AddQuestionAsync(
        HttpContext httpContext,
        IBusiness _business,
        ISessionBusiness _sessionBusiness,
        IData _data)
    {
        var createResponse = await _business.CaptchaAddBusiness.AddAsync(_data, _sessionBusiness);

        httpContext.Response.Headers[Constant.HttpHeaderName.ResultCode] = createResponse.ResultCode.ToString();
        httpContext.Response.Headers[Constant.HttpHeaderName.ResultMessage] = createResponse.ResultMessage;

        if (createResponse.ResultCode != ResponseResultCode.Success) return Results.Empty;

        return Results.Stream(createResponse.Stream!, "image/png");
    }

    internal static async Task<Response> UpdateAsync(
        IBusiness _business,
        IData _data,
        ISessionBusiness _sessionBusiness,
        [FromBody] CaptchaUpdateRequest captchaUpdateRequest)
    {
        return await _business.CaptchaUpdateBusiness.UpdateAsync(_data, _sessionBusiness, captchaUpdateRequest);
    }
}
