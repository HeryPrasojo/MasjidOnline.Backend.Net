using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Accountancy.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class AccountancyEndpoint
{
    internal static class Expenditure
    {
        internal static async Task<Response> AddAsync(
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] AddRequest? addRequest)
        {
            return await _business.Accountancy.Expenditure.Add.AddAsync(session, _data, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] ApproveRequest? approveRequest)
        {
            return await _business.Accountancy.Expenditure.Approve.ApproveAsync(session, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] CancelRequest? cancelRequest)
        {
            return await _business.Accountancy.Expenditure.Cancel.CancelAsync(session, _data, cancelRequest);
        }

        internal static async Task<Response<GetManyResponse<GetManyResponseRecord>>> GetManyAsync(
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] GetManyRequest? getManyRequest)
        {
            return await _business.Accountancy.Expenditure.GetMany.GetAsync(_data, session, getManyRequest);
        }

        internal static async Task<Response<GetOneResponse>> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] GetOneRequest? getOneRequest)
        {
            return await _business.Accountancy.Expenditure.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] RejectRequest? rejectRequest)
        {
            return await _business.Accountancy.Expenditure.Reject.RejectAsync(session, _data, rejectRequest);
        }
    }
}
