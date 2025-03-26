using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    internal static class Internal
    {
        internal static async Task<Response> AddAsync(
            Business.User.Interface.Internal.IAddBusiness _addBusiness,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.AddRequest? addRequest)
        {
            return await _addBusiness.AddAsync(_sessionBusiness, _data, addRequest);
        }

        internal static async Task<Response> ApproveAsync(
            Business.User.Interface.Internal.IApproveBusiness _approveBusiness,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.ApproveRequest? approveRequest)
        {
            return await _approveBusiness.ApproveAsync(_sessionBusiness, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            Business.User.Interface.Internal.ICancelBusiness _cancelBusiness,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.CancelRequest? cancelRequest)
        {
            return await _cancelBusiness.CancelAsync(_sessionBusiness, _data, cancelRequest);
        }

        internal static async Task<GetManyResponse<Business.User.Interface.Model.Internal.GetManyResponseRecord>> GetManyAsync(
            ISessionBusiness _sessionBusiness,
            Business.User.Interface.Internal.IGetManyBusiness _getManyBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.GetManyRequest? getManyRequest)
        {
            return await _getManyBusiness.GetAsync(_sessionBusiness, _data, getManyRequest);
        }

        internal static async Task<GetManyResponse<Business.User.Interface.Model.Internal.GetManyNewResponseRecord>> GetManyNewAsync(
            Business.User.Interface.Internal.IGetManyNewBusiness _getManyNewBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.GetManyNewRequest? getManyNewRequest)
        {
            return await _getManyNewBusiness.GetAsync(_data, getManyNewRequest);
        }

        internal static async Task<Business.User.Interface.Model.Internal.GetOneResponse> GetOneAsync(
            Business.User.Interface.Internal.IGetOneBusiness _getOneBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.GetOneRequest? getOneRequest)
        {
            return await _getOneBusiness.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Business.User.Interface.Model.Internal.GetOneNewResponse> GetOneNewAsync(
            Business.User.Interface.Internal.IGetOneNewBusiness _getOneNewBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.GetOneNewRequest? getOneNewRequest)
        {
            return await _getOneNewBusiness.GetAsync(_data, getOneNewRequest);
        }

        internal static async Task<Response> RejectAsync(
            Business.User.Interface.Internal.IRejectBusiness _rejectBusiness,
            ISessionBusiness _sessionBusiness,
            IData _data,
            [FromBody] Business.User.Interface.Model.Internal.RejectRequest? rejectRequest)
        {
            return await _rejectBusiness.RejectAsync(_sessionBusiness, _data, rejectRequest);
        }
    }

    internal static class User
    {
        internal static async Task<Response> LoginAsync(
            Business.User.Interface.User.ILoginBusiness _loginBusiness,
            IData _data,
            ISessionBusiness _sessionBusiness,
            [FromBody] Business.User.Interface.Model.User.LoginRequest? loginRequest)
        {
            return await _loginBusiness.LoginAsync(_data, _sessionBusiness, loginRequest);
        }

        internal static async Task<Response> SetPasswordAsync(
            ISessionBusiness _sessionBusiness,
            IData _data,
            Business.User.Interface.User.ISetPasswordBusiness _setPasswordBusiness,
            [FromBody] Business.User.Interface.Model.User.SetPasswordRequest? setPasswordRequest)
        {
            return await _setPasswordBusiness.SetAsync(_sessionBusiness, _data, setPasswordRequest);
        }
    }
}
