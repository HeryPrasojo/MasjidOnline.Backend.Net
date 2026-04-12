using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extensions;
using Microsoft.AspNetCore.SignalR;

namespace MasjidOnline.Api.Web;

public class ConnectionHub(IBusiness _business) : Hub
{
    // hack handle flood
    private static readonly ConcurrentDictionary<string, Session> _sessions = new();

    private Session Session => _sessions[Context.ConnectionId];

    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext() ?? throw new ErrorException("GetHttpContext fail");

        var _session = httpContext.RequestServices.GetServiceOrThrow<Session>();

        var newSession = new Session
        {
            Id = _session.Id,
            UserId = _session.UserId,
            CultureInfo = _session.CultureInfo,
        };

        var result = _sessions.TryAdd(Context.ConnectionId, newSession);

        await base.OnConnectedAsync();

        if (!result)
        {
            Context.Abort();

            throw new ErrorException("Session removal fail");
        }
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var result = _sessions.TryRemove(Context.ConnectionId, out var _);

        await base.OnDisconnectedAsync(exception);

        if (!result) throw new ErrorException("Session removal fail");
    }


    public async Task<Response> UserInternalAdd(IData _data, Business.Model.User.Internal.AddRequest? addRequest)
    {
        return await _business.User.Internal.Add.AddAsync(Session, _data, addRequest);
    }

    public async Task<Response> UserInternalApprove(IData _data, Business.Model.User.Internal.ApproveRequest? approveRequest)
    {
        return await _business.User.Internal.Approve.ApproveAsync(Session, _data, approveRequest);
    }

    public async Task<Response> UserInternalCancel(IData _data, Business.Model.User.Internal.CancelRequest? cancelRequest)
    {
        return await _business.User.Internal.Cancel.CancelAsync(Session, _data, cancelRequest);
    }

    public async Task<Response<TableResponse<Business.Model.User.Internal.TableResponseRecord>>> UserInternalTable(
        IData _data,
        Business.Model.User.Internal.TableRequest? tableRequest)
    {
        return await _business.User.Internal.GetTable.GetAsync(Session, _data, tableRequest);
    }

    public async Task<Response<Business.Model.User.Internal.ViewResponse>> UserInternalView(
        IData _data,
        Business.Model.User.Internal.ViewRequest? viewRequest)
    {
        return await _business.User.Internal.GetView.GetAsync(Session, _data, viewRequest);
    }

    public async Task<Response> UserInternalReject(IData _data, Business.Model.User.Internal.RejectRequest? rejectRequest)
    {
        return await _business.User.Internal.Reject.RejectAsync(Session, _data, rejectRequest);
    }


    public async Task<Response> UserInternalPermissionUpdate(
        IData _data,
        Business.Model.Authorization.UserInternalPermission.UpdateRequest? updateRequest)
    {
        return await _business.Authorization.Authorization.UserInternalPermission.Update.UpdateAsync(_data, Session, updateRequest);
    }

    public async Task<Response<Business.Model.Authorization.UserInternalPermission.ViewResponse>> UserInternalPermissionView(
        IData _data,
        Business.Model.Authorization.UserInternalPermission.ViewRequest? viewRequest)
    {
        return await _business.Authorization.Authorization.UserInternalPermission.GetView.GetAsync(Session, _data, viewRequest);
    }


    public async Task UserUserLogout(IData _data)
    {
        await _business.User.User.Logout.LogoutAsync(Session, _data);

        await Clients.Caller.SendAsync("logout");

        Context.Abort();
    }
}
