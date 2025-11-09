using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Api.Web;

public class ConnectionHub(IBusiness _business) : Hub
{
    private static readonly ConcurrentDictionary<string, Session> _sessions = new();

    private Session Session => _sessions[Context.ConnectionId];

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"\nOnConnectedAsync HashCode={GetHashCode()}\n");
        var httpContext = Context.GetHttpContext();

        var _session = httpContext?.RequestServices.GetService<Session>() ?? throw new ErrorException("Get session fail");

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
        Console.WriteLine($"\nOnDisconnectedAsync HashCode={GetHashCode()}\n");
        var result = _sessions.TryRemove(Context.ConnectionId, out var _);

        await base.OnDisconnectedAsync(exception);

        if (!result) throw new ErrorException("Session removal fail");
    }


    public async Task UserUserLogoutAsync(
        IData _data)
    {
        Console.WriteLine($"\nUserUserLogoutAsync HashCode={GetHashCode()}\n");
        await _business.User.User.Logout.LogoutAsync(Session, _data);

        Context.Abort();
    }
}
