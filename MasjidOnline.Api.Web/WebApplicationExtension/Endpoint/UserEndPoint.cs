using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class UserEndpoint
{
    internal static class Internal
    {
        internal static async Task<Response> AddAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.AddRequest? addRequest)
        {
            return await _business.User.Internal.Add.AddAsync(session, _data, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.ApproveRequest? approveRequest)
        {
            return await _business.User.Internal.Approve.ApproveAsync(session, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.CancelRequest? cancelRequest)
        {
            return await _business.User.Internal.Cancel.CancelAsync(session, _data, cancelRequest);
        }

        internal static async Task<Response<GetManyResponse<Business.User.Interface.Model.Internal.GetManyResponseRecord>>> GetManyAsync(
            Session session,
            IBusiness _business,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.GetManyRequest? getManyRequest)
        {
            return await _business.User.Internal.GetMany.GetAsync(session, _data, getManyRequest);
        }

        internal static async Task<Response<Business.User.Interface.Model.Internal.GetOneResponse>> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.GetOneRequest? getOneRequest)
        {
            return await _business.User.Internal.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.RejectRequest? rejectRequest)
        {
            return await _business.User.Internal.Reject.RejectAsync(session, _data, rejectRequest);
        }
    }

    internal static class User
    {
        internal static async Task<Response> LoginAsync(
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] Business.User.Interface.Model.User.LoginRequest? loginRequest)
        {
            return await _business.User.User.LoginEmail.LoginAsync(_data, session, loginRequest);
        }

        internal static async Task<Response<string>> SetPasswordAsync(
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] Business.User.Interface.Model.User.SetPasswordRequest? setPasswordRequest)
        {
            return await _business.User.User.SetPassword.SetAsync(session, _data, setPasswordRequest);
        }
    }
}
