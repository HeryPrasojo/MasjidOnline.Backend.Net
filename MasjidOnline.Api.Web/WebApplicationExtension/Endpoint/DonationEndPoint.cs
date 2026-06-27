using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Payment.Payment;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class DonationEndpoint
{
    internal static class Donation
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
            var addRequest = new Business.Model.Donation.Donation.AddRequest
            {
                Amount = amount,
                CaptchaToken = captchaToken,
                Files = files?.Select(f => f.OpenReadStream()),
                ManualDateTime = manualDateTime,
                ManualNotes = manualNotes,
                MunfiqName = munfiqName,
                PaymentType = paymentType,
            };

            var response = await _business.Donation.Donation.Add.AddAsync(_data, session, addRequest);

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
        internal static async Task<Response<string>> GetRecommendationNoteAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] GetRecommendationNoteRequest getRecommendationNoteRequest)
        {
            return await _business.Donation.Donation.GetRecommendationNote.GetAsync(_data, session, getRecommendationNoteRequest);
        }

        internal static async Task<Response<TableResponse<Business.Model.Donation.Donation.TableResponseRecord>>> GetTableAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Donation.Donation.TableRequest? getTableRequest)
        {
            return await _business.Donation.Donation.GetTable.GetAsync(session, _data, getTableRequest);
        }

        internal static async Task<Response<Business.Model.Donation.Donation.ViewResponse>> GetViewAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Donation.Donation.ViewRequest? viewRequest)
        {
            return await _business.Donation.Donation.GetView.GetAsync(session, _data, viewRequest);
        }
    }
}


