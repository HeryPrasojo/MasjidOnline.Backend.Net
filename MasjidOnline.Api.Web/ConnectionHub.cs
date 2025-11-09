using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.SignalR;

namespace MasjidOnline.Api.Web;

public class ConnectionHub(IBusiness _business) : Hub
{
    private static readonly ConcurrentDictionary<string, Session> _sessions = new();

    private Session Session => _sessions[Context.ConnectionId];

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"\nHashCode={GetHashCode()}\n");
        var httpContext = Context.GetHttpContext();

        var _session = httpContext?.Items["Session"] as Session ?? throw new ErrorException("Session not found");

        _business.Authorization.AuthorizeNonAnonymous(_session);

        var result = _sessions.TryAdd(Context.ConnectionId, _session);

        await base.OnConnectedAsync();

        if (!result)
        {
            Context.Abort();

            throw new ErrorException("Session removal fail");
        }
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"\nHashCode={GetHashCode()}\n");
        var result = _sessions.TryRemove(Context.ConnectionId, out var _);

        await base.OnDisconnectedAsync(exception);

        if (!result) throw new ErrorException("Session removal fail");
    }


    public async Task<Response> UserUserLogoutAsync(
        IData _data)
    {
        Console.WriteLine($"\nHashCode={GetHashCode()}\n");
        Context.Abort();

        return await _business.User.User.Logout.LogoutAsync(Session, _data);
    }
}
