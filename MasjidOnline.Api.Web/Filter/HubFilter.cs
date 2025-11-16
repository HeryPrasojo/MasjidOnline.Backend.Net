using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library;
using MasjidOnline.Library.Extensions;
using Microsoft.AspNetCore.SignalR;

namespace MasjidOnline.Api.Web.Filter;

public class HubFilter(IBusiness _business) : IHubFilter
{
    public async Task OnConnectedAsync(HubLifetimeContext context, Func<HubLifetimeContext, Task> next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context.ServiceProvider, exception);

            throw;
        }
    }

    public async Task OnDisconnectedAsync(HubLifetimeContext context, Exception? exception, Func<HubLifetimeContext, Exception?, Task> next)
    {
        try
        {
            await next(context, exception);
        }
        catch (Exception catchException)
        {
            await HandleExceptionAsync(context.ServiceProvider, catchException);

            throw;
        }
    }

    public async ValueTask<object?> InvokeMethodAsync(HubInvocationContext invocationContext, Func<HubInvocationContext, ValueTask<object?>> next)
    {
        try
        {
            var result = await next(invocationContext);

            if (result == default) return default;


            var session = invocationContext.ServiceProvider.GetServiceOrThrow<Session>();

            return JsonSerializer.Serialize(result, session.CultureInfo);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(invocationContext.ServiceProvider, exception);

            throw;
        }
    }

    private async Task HandleExceptionAsync(IServiceProvider serviceProvider, Exception exception)
    {
        var _data = serviceProvider.GetServiceOrThrow<IData>();

        await _business.Event.Exception.HandleAsync(_data, exception);
    }
}
