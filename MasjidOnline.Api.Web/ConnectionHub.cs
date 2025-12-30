using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Business.Model.User.Internal;
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


    public async Task<Response> UserInternalAdd(
        IData _data,
        AddRequest? addRequest)
    {
        return await _business.User.Internal.Add.AddAsync(Session, _data, addRequest);
    }

    public async Task<Response<GetManyResponse<GetManyResponseRecord>>> UserInternalList(
        IData _data,
        GetManyRequest? getManyRequest)
    {
        return await _business.User.Internal.GetMany.GetAsync(Session, _data, getManyRequest);
    }

    public async Task UserUserLogout(IData _data)
    {
        await _business.User.User.Logout.LogoutAsync(Session, _data);

        Context.Abort();
    }
}
