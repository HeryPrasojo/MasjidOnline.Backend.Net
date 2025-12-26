using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Payment;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class InfaqEndpoint
{
    internal static class Expire
    {
        internal static async Task<Response> AddAsync(
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] Business.Model.Infaq.Expire.AddRequest? addRequest)
        {
            return await _business.Infaq.Expire.Add.AddAsync(_data, session, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Expire.ApproveRequest? approveRequest)
        {
            return await _business.Infaq.Expire.Approve.ApproveAsync(session, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Expire.CancelRequest? cancelRequest)
        {
            return await _business.Infaq.Expire.Cancel.CancelAsync(session, _data, cancelRequest);
        }

        internal static async Task<Response<GetManyResponse<Business.Model.Infaq.Expire.GetManyResponseRecord>>> GetManyAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Expire.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Expire.GetMany.GetAsync(_data, session, getManyRequest);
        }

        internal static async Task<Response<Business.Model.Infaq.Expire.GetOneResponse>> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Model.Infaq.Expire.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Expire.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Expire.RejectRequest? rejectRequest)
        {
            return await _business.Infaq.Expire.Reject.RejectAsync(session, _data, rejectRequest);
        }
    }

    internal static class Infaq
    {
        internal static async Task<Response> AddAnonymAsync(
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
            var addByAnonymRequest = new Business.Model.Infaq.Infaq.AddByAnonymRequest
            {
                Amount = amount,
                CaptchaToken = captchaToken,
                Files = files?.Select(f => f.OpenReadStream()),
                ManualDateTime = manualDateTime,
                ManualNotes = manualNotes,
                MunfiqName = munfiqName,
                PaymentType = paymentType,
            };

            var response = await _business.Infaq.Infaq.AddByAnonym.AddAsync(_data, session, addByAnonymRequest);

            if (addByAnonymRequest.Files != default)
            {
                foreach (var file in addByAnonymRequest.Files)
                {
                    await file.FlushAsync();

                    await file.DisposeAsync();
                }
            }

            return response;
        }

        internal static async Task<Response<GetManyResponse<Business.Model.Infaq.Infaq.GetManyResponseRecord>>> GetManyAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Infaq.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Infaq.GetMany.GetAsync(session, _data, getManyRequest);
        }

        internal static async Task<Response<Business.Model.Infaq.Infaq.GetOneResponse>> GetOneAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Infaq.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Infaq.GetOne.GetAsync(session, _data, getOneRequest);
        }
    }

    internal static class Success
    {
        internal static async Task<Response> AddAsync(
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] Business.Model.Infaq.Success.AddRequest? addRequest)
        {
            return await _business.Infaq.Success.Add.AddAsync(_data, session, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Success.ApproveRequest? approveRequest)
        {
            return await _business.Infaq.Success.Approve.ApproveAsync(session, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Success.CancelRequest? cancelRequest)
        {
            return await _business.Infaq.Success.Cancel.CancelAsync(session, _data, cancelRequest);
        }

        internal static async Task<Response<GetManyResponse<Business.Model.Infaq.Success.GetManyResponseRecord>>> GetManyAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Success.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Success.GetMany.GetAsync(_data, session, getManyRequest);
        }

        internal static async Task<Response<Business.Model.Infaq.Success.GetOneResponse>> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Model.Infaq.Success.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Success.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Success.RejectRequest? rejectRequest)
        {
            return await _business.Infaq.Success.Reject.RejectAsync(session, _data, rejectRequest);
        }
    }

    internal static class Void
    {
        internal static async Task<Response> AddAsync(
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] Business.Model.Infaq.Void.AddRequest? addRequest)
        {
            return await _business.Infaq.Void.Add.AddAsync(_data, session, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Void.ApproveRequest? approveRequest)
        {
            return await _business.Infaq.Void.Approve.ApproveAsync(session, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Void.CancelRequest? cancelRequest)
        {
            return await _business.Infaq.Void.Cancel.CancelAsync(session, _data, cancelRequest);
        }

        internal static async Task<Response<GetManyResponse<Business.Model.Infaq.Void.GetManyResponseRecord>>> GetManyAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Void.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Void.GetMany.GetAsync(_data, session, getManyRequest);
        }

        internal static async Task<Response<Business.Model.Infaq.Void.GetOneResponse>> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Model.Infaq.Void.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Void.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Model.Infaq.Void.RejectRequest? rejectRequest)
        {
            return await _business.Infaq.Void.Reject.RejectAsync(session, _data, rejectRequest);
        }
    }
}
