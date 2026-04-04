using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Payment.Payment;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class InfaqEndpoint
{
    internal static class Infaq
    {
        internal static async Task<Response> AddAsync(
            HttpContext _httpContext,
            IBusiness _business,
            IData _data,
            Session session,
            [FromForm] decimal? amount,
            [FromForm] string? captchaToken,
            [FromForm] DateTime? manualDateTime,
            [FromForm] string? manualNotes,
            [FromForm] string? munfiqName,
            [FromForm] PaymentType? paymentType,
            [FromForm] IFormFileCollection? files)
        {
            var addRequest = new Business.Model.Infaq.Infaq.AddRequest
            {
                Amount = amount,
                CaptchaToken = captchaToken,
                Files = files?.Select(f => f.OpenReadStream()),
                ManualDateTime = manualDateTime,
                ManualNotes = manualNotes,
                MunfiqName = munfiqName,
                PaymentType = paymentType,
            };

            var response = await _business.Infaq.Infaq.Add.AddAsync(_data, session, addRequest);

            if (addRequest.Files != default)
            {
                foreach (var file in addRequest.Files)
                {
                    await file.FlushAsync();

                    await file.DisposeAsync();
                }
            }

            return response;
        }

        internal static async Task<Response<GetTableResponse<Business.Model.Infaq.Infaq.GetTableResponseRecord>>> GetTableAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Infaq.GetTableRequest? getTableRequest)
        {
            return await _business.Infaq.Infaq.GetTable.GetAsync(session, _data, getTableRequest);
        }

        internal static async Task<Response<Business.Model.Infaq.Infaq.GetViewResponse>> GetViewAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Infaq.GetViewRequest? getViewRequest)
        {
            return await _business.Infaq.Infaq.GetView.GetAsync(session, _data, getViewRequest);
        }
    }
}
