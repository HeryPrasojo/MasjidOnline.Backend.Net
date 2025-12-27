using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Business.Model.User.Internal;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class UserEndpoint
{
    internal static class Internal
    {
        internal static async Task<Response> ApproveAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] ApproveRequest? approveRequest)
        {
            return await _business.User.Internal.Approve.ApproveAsync(session, _data, approveRequest);
        }

        internal static async Task<Response> CancelAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] CancelRequest? cancelRequest)
        {
            return await _business.User.Internal.Cancel.CancelAsync(session, _data, cancelRequest);
        }

        internal static async Task<Response<GetOneResponse>> GetOneAsync(
            IBusiness _business,
            IData _data,
            [FromBody] GetOneRequest? getOneRequest)
        {
            return await _business.User.Internal.GetOne.GetAsync(_data, getOneRequest);
        }

        internal static async Task<Response> RejectAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] RejectRequest? rejectRequest)
        {
            return await _business.User.Internal.Reject.RejectAsync(session, _data, rejectRequest);
        }
    }

    internal static class User
    {
        internal static async Task<Response> LoginAsync(
            HttpContext _httpContext,
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] LoginRequest? loginRequest)
        {
            if (loginRequest != default)
            {
                loginRequest.UserAgent ??= _httpContext.Request.Headers.UserAgent.FirstOrDefault();

                loginRequest.IpAddress = _httpContext.Request.Headers["X-Forwarded-For"]
                    .FirstOrDefault()
                    ?.Split(',')
                    .FirstOrDefault()
                    ?? _httpContext.Connection.RemoteIpAddress?.ToString();
            }

            return await _business.User.User.Login.LoginAsync(_data, session, loginRequest);
        }

        internal static async Task<Response> RegisterAsync(
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] RegisterRequest? registerRequest)
        {
            return await _business.User.User.Register.RegisterAsync(_data, session, registerRequest);
        }

        internal static async Task<Response> VerifyRegisterAsync(
            HttpContext _httpContext,
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] VerifyRegisterRequest? verifyRegisterRequest)
        {
            if (verifyRegisterRequest != default)
            {
                verifyRegisterRequest.UserAgent ??= _httpContext.Request.Headers.UserAgent.FirstOrDefault();

                verifyRegisterRequest.IpAddress = _httpContext.Request.Headers["X-Forwarded-For"]
                    .FirstOrDefault()
                    ?.Split(',')
                    .FirstOrDefault()
                    ?? _httpContext.Connection.RemoteIpAddress?.ToString();
            }

            return await _business.User.User.VerifyRegister.VerifyAsync(session, _data, verifyRegisterRequest);
        }

        internal static async Task<Response> VerifySetPasswordAsync(
            HttpContext _httpContext,
            IBusiness _business,
            IData _data,
            Session session,
            [FromBody] VerifySetPasswordRequest? verifySetPasswordRequest)
        {
            if (verifySetPasswordRequest != default)
            {
                verifySetPasswordRequest.UserAgent ??= _httpContext.Request.Headers.UserAgent.FirstOrDefault();

                verifySetPasswordRequest.IpAddress = _httpContext.Request.Headers["X-Forwarded-For"]
                    .FirstOrDefault()
                    ?.Split(',')
                    .FirstOrDefault()
                    ?? _httpContext.Connection.RemoteIpAddress?.ToString();
            }

            return await _business.User.User.VerifySetPassword.VerifyAsync(session, _data, verifySetPasswordRequest);
        }
    }
}
