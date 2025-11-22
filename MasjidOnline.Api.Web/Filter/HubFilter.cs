using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
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
            var _data = context.ServiceProvider.GetServiceOrThrow<IData>();

            await _business.Event.Exception.LogAsync(_data, exception);

            // todo signalr custom exception response
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
            var _data = context.ServiceProvider.GetServiceOrThrow<IData>();

            await _business.Event.Exception.LogAsync(_data, catchException);

            throw;
        }
    }

    public async ValueTask<object?> InvokeMethodAsync(HubInvocationContext invocationContext, Func<HubInvocationContext, ValueTask<object?>> next)
    {
        try
        {
            return await next(invocationContext);
        }
        catch (Exception exception)
        {
            var exceptionResponse = _business.ExceptionResponse.Build(exception);

            if (exceptionResponse.ResultCode == ResponseResultCode.Error)
            {
                var _data = invocationContext.ServiceProvider.GetServiceOrThrow<IData>();

                await _business.Event.Exception.LogAsync(_data, exception);
            }

            return exceptionResponse;
        }
    }
}