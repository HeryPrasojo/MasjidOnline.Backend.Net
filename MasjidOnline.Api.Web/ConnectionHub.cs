using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.SignalR;

namespace MasjidOnline.Api.Web;

public class ConnectionHub(
    IBusiness _business,
    Session _session) : Hub
{
    private static readonly ConcurrentDictionary<string, Session> _sessions = new();

    public override Task OnConnectedAsync()
    {
        _business.Authorization.AuthorizeNonAnonymous(_session);

        _sessions.TryAdd(Context.ConnectionId, _session);

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }


    internal static async Task<Response> UserUserLogoutAsync(
        IBusiness _business,
        IData _data,
        Session session)
    {
        return await _business.User.User.Logout.LogoutAsync(session, _data);
    }
}
