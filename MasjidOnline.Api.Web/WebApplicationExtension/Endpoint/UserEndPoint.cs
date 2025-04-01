using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class UserEndPoint
{
    internal static class Internal
    {
        internal static async Task<Response> AddAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.AddRequest? addRequest)
        {
            return await _business.User.Internal.Add.AddAsync(_sessionBusiness, _data, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.ApproveRequest? approveRequest)
        {
            return await _business.User.Internal.Approve.ApproveAsync(_sessionBusiness, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.CancelRequest? cancelRequest)
        {
            return await _business.User.Internal.Cancel.CancelAsync(_sessionBusiness, _data, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.User.Interface.Model.Internal.GetManyResponseRecord>> GetManyAsync(
            ISessionBusiness _sessionBusiness,
            IBusiness _business,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.GetManyRequest? getManyRequest)
        {
            return await _business.User.Internal.GetMany.GetAsync(_sessionBusiness, _data, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.User.Interface.Model.Internal.GetManyNewResponseRecord>> GetManyNewAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.GetManyNewRequest? getManyNewRequest)
        {
            return await _business.User.Internal.GetManyNew.GetAsync(_data, getManyNewRequest);
        }

        internal static async Task<Business.User.Interface.Model.Internal.GetOneResponse> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.GetOneRequest? getOneRequest)
        {
            return await _business.User.Internal.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Business.User.Interface.Model.Internal.GetOneNewResponse> GetOneNewAsync(
            IBusiness _business,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.GetOneNewRequest? getOneNewRequest)
        {
            return await _business.User.Internal.GetOneNew.GetAsync(_data, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.RejectRequest? rejectRequest)
        {
            return await _business.User.Internal.Reject.RejectAsync(_sessionBusiness, _data, rejectRequest);
        }
    }

    internal static class User
    {
        internal static async Task<Response> LoginAsync(
            IBusiness _business,
            IData _data,
            ISessionBusiness _sessionBusiness,
            [FromBody] Business.User.Interface.Model.User.LoginRequest? loginRequest)
        {
            return await _business.User.User.Login.LoginAsync(_data, _sessionBusiness, loginRequest);
        }

        internal static async Task<Response> SetPasswordAsync(
            IBusiness _business,
            IData _data,
            ISessionBusiness _sessionBusiness,
            [FromBody] Business.User.Interface.Model.User.SetPasswordRequest? setPasswordRequest)
        {
            return await _business.User.User.SetPassword.SetAsync(_sessionBusiness, _data, setPasswordRequest);
        }
    }
}
