using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Payment.Interface.Model;
using MasjidOnline.Business.Session.Interface.Model;
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
            [FromBody] Business.Infaq.Interface.Model.Expire.AddRequest? addRequest)
        {
            return await _business.Infaq.Expire.Add.AddAsync(_data, session, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.ApproveRequest? approveRequest)
        {
            return await _business.Infaq.Expire.Approve.ApproveAsync(session, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.CancelRequest? cancelRequest)
        {
            return await _business.Infaq.Expire.Cancel.CancelAsync(session, _data, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Expire.GetManyResponseRecord>> GetManyAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Expire.GetMany.GetAsync(_data, getManyRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Expire.GetOneResponse> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Expire.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.RejectRequest? rejectRequest)
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
            [FromForm] PaymentType? paymentType)
        {
            var addByAnonymRequest = new Business.Infaq.Interface.Model.Infaq.AddByAnonymRequest
            {
                Amount = amount,
                CaptchaToken = captchaToken,
                Files = _httpContext.Request.Form.Files.Select(f => f.OpenReadStream()),
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

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Infaq.GetManyResponseRecord>> GetManyAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Infaq.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Infaq.GetMany.GetAsync(session, _data, getManyRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Infaq.GetOneResponse> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Infaq.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Infaq.GetOne.GetAsync(_data, getOneRequest);
        }
    }

    internal static class Success
    {
        internal static async Task<Response> AddAsync(
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] Business.Infaq.Interface.Model.Success.AddRequest? addRequest)
        {
            return await _business.Infaq.Success.Add.AddAsync(_data, session, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.ApproveRequest? approveRequest)
        {
            return await _business.Infaq.Success.Approve.ApproveAsync(session, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.CancelRequest? cancelRequest)
        {
            return await _business.Infaq.Success.Cancel.CancelAsync(session, _data, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Success.GetManyResponseRecord>> GetManyAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Success.GetMany.GetAsync(_data, getManyRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Success.GetOneResponse> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Success.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.RejectRequest? rejectRequest)
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
            [FromBody] Business.Infaq.Interface.Model.Void.AddRequest? addRequest)
        {
            return await _business.Infaq.Void.Add.AddAsync(_data, session, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.ApproveRequest? approveRequest)
        {
            return await _business.Infaq.Void.Approve.ApproveAsync(session, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.CancelRequest? cancelRequest)
        {
            return await _business.Infaq.Void.Cancel.CancelAsync(session, _data, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Void.GetManyResponseRecord>> GetManyAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Void.GetMany.GetAsync(_data, getManyRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Void.GetOneResponse> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Void.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.RejectRequest? rejectRequest)
        {
            return await _business.Infaq.Void.Reject.RejectAsync(session, _data, rejectRequest);
        }
    }
}
