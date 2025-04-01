using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class InfaqEndPoint
{
    internal static class Expire
    {
        internal static async Task<Response> AddAsync(
            IBusiness _business,
            IData _data,
            ISessionBusiness _sessionBusiness,
            [FromBody] Business.Infaq.Interface.Model.Expire.AddRequest? addRequest)
        {
            return await _business.Infaq.Expire.Add.AddAsync(_data, _sessionBusiness, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.ApproveRequest? approveRequest)
        {
            return await _business.Infaq.Expire.Approve.ApproveAsync(_sessionBusiness, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.CancelRequest? cancelRequest)
        {
            return await _business.Infaq.Expire.Cancel.CancelAsync(_sessionBusiness, _data, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Expire.GetManyResponseRecord>> GetManyAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Expire.GetMany.GetAsync(_data, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Expire.GetManyNewResponseRecord>> GetManyNewAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.GetManyNewRequest? getManyNewRequest)
        {
            return await _business.Infaq.Expire.GetManyNew.GetAsync(_data, getManyNewRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Expire.GetOneResponse> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Expire.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Expire.GetOneNewResponse> GetOneNewAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.GetOneNewRequest? getOneNewRequest)
        {
            return await _business.Infaq.Expire.GetOneNew.GetAsync(_data, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Expire.RejectRequest? rejectRequest)
        {
            return await _business.Infaq.Expire.Reject.RejectAsync(_sessionBusiness, _data, rejectRequest);
        }
    }

    internal static class Infaq
    {
        internal static async Task<Response> AddAnonymAsync(
            IBusiness _business,
            IData _data,
            ISessionBusiness _sessionBusiness,
            [FromBody] Business.Infaq.Interface.Model.Infaq.AddByAnonymRequest? addByAnonymRequest)
        {
            return await _business.Infaq.Infaq.AddAnonym.AddAsync(_data, _sessionBusiness, addByAnonymRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Infaq.GetManyResponseRecord>> GetManyAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Infaq.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Infaq.GetMany.GetAsync(_data, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Infaq.GetManyDueResponseRecord>> GetManyDueAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Infaq.GetManyDueRequest? getManyDueRequest)
        {
            return await _business.Infaq.Infaq.GetManyDue.GetAsync(_data, getManyDueRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Infaq.GetOneResponse> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Infaq.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Infaq.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Infaq.GetOneDueResponse> GetOneDueAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Infaq.GetOneDueRequest? getOneDueRequest)
        {
            return await _business.Infaq.Infaq.GetOneDue.GetAsync(_data, getOneDueRequest);
        }
    }

    internal static class Success
    {
        internal static async Task<Response> AddAsync(
            IBusiness _business,
            IData _data,
            ISessionBusiness _sessionBusiness,
            [FromBody] Business.Infaq.Interface.Model.Success.AddRequest? addRequest)
        {
            return await _business.Infaq.Success.Add.AddAsync(_data, _sessionBusiness, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.ApproveRequest? approveRequest)
        {
            return await _business.Infaq.Success.Approve.ApproveAsync(_sessionBusiness, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.CancelRequest? cancelRequest)
        {
            return await _business.Infaq.Success.Cancel.CancelAsync(_sessionBusiness, _data, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Success.GetManyResponseRecord>> GetManyAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Success.GetMany.GetAsync(_data, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Success.GetManyNewResponseRecord>> GetManyNewAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.GetManyNewRequest? getManyNewRequest)
        {
            return await _business.Infaq.Success.GetManyNew.GetAsync(_data, getManyNewRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Success.GetOneResponse> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Success.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Success.GetOneNewResponse> GetOneNewAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.GetOneNewRequest? getOneNewRequest)
        {
            return await _business.Infaq.Success.GetOneNew.GetAsync(_data, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Success.RejectRequest? rejectRequest)
        {
            return await _business.Infaq.Success.Reject.RejectAsync(_sessionBusiness, _data, rejectRequest);
        }
    }

    internal static class Void
    {
        internal static async Task<Response> AddAsync(
            IBusiness _business,
            IData _data,
            ISessionBusiness _sessionBusiness,
            [FromBody] Business.Infaq.Interface.Model.Void.AddRequest? addRequest)
        {
            return await _business.Infaq.Void.Add.AddAsync(_data, _sessionBusiness, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.ApproveRequest? approveRequest)
        {
            return await _business.Infaq.Void.Approve.ApproveAsync(_sessionBusiness, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.CancelRequest? cancelRequest)
        {
            return await _business.Infaq.Void.Cancel.CancelAsync(_sessionBusiness, _data, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Void.GetManyResponseRecord>> GetManyAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.GetManyRequest? getManyRequest)
        {
            return await _business.Infaq.Void.GetMany.GetAsync(_data, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.Infaq.Interface.Model.Void.GetManyNewResponseRecord>> GetManyNewAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.GetManyNewRequest? getManyNewRequest)
        {
            return await _business.Infaq.Void.GetManyNew.GetAsync(_data, getManyNewRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Void.GetOneResponse> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.GetOneRequest? getOneRequest)
        {
            return await _business.Infaq.Void.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Business.Infaq.Interface.Model.Void.GetOneNewResponse> GetOneNewAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.GetOneNewRequest? getOneNewRequest)
        {
            return await _business.Infaq.Void.GetOneNew.GetAsync(_data, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.Infaq.Interface.Model.Void.RejectRequest? rejectRequest)
        {
            return await _business.Infaq.Void.Reject.RejectAsync(_sessionBusiness, _data, rejectRequest);
        }
    }
}
