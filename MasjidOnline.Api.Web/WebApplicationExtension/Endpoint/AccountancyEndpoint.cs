using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface.Model;
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
            [FromBody] Business.Accountancy.Interface.Model.Expenditure.AddRequest? addRequest)
        {
            return await _business.Accountancy.Expenditure.Add.AddAsync(session, _data, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Accountancy.Interface.Model.Expenditure.ApproveRequest? approveRequest)
        {
            return await _business.Accountancy.Expenditure.Approve.ApproveAsync(session, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Accountancy.Interface.Model.Expenditure.CancelRequest? cancelRequest)
        {
            return await _business.Accountancy.Expenditure.Cancel.CancelAsync(session, _data, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.Accountancy.Interface.Model.Expenditure.GetManyResponseRecord>> GetManyAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Accountancy.Interface.Model.Expenditure.GetManyRequest? getManyRequest)
        {
            return await _business.Accountancy.Expenditure.GetMany.GetAsync(_data, getManyRequest);
        }

        internal static async Task<Business.Accountancy.Interface.Model.Expenditure.GetOneResponse> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.Accountancy.Interface.Model.Expenditure.GetOneRequest? getOneRequest)
        {
            return await _business.Accountancy.Expenditure.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.Accountancy.Interface.Model.Expenditure.RejectRequest? rejectRequest)
        {
            return await _business.Accountancy.Expenditure.Reject.RejectAsync(session, _data, rejectRequest);
        }
    }
}
