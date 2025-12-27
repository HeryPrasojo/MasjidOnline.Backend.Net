using System;
using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MasjidOnline.Api.Web.HostedServices;

public class SchedulerHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IBusiness _business;
    private readonly Timer _timer; // hack separate hourly, daily, weekly, monthly, yearly.

    public SchedulerHostedService(IServiceProvider serviceProvider, IBusiness business)
    {
        _timer = new(TimerCallbackAsync);
        _serviceProvider = serviceProvider;
        _business = business;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
#if !DEBUG
        ChangeTimer();
#endif

        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _timer.DisposeAsync();
    }


    private void ChangeTimer()
    {
        var utcNow = DateTime.UtcNow;

        var dueDateTime = new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, 0, 0).AddHours(1);

        _timer.Change(dueDateTime - utcNow, TimeSpan.FromHours(1));
    }

    private async Task DoDailyAsync(IData _data)
    {
        await _business.Session.Expire.ExpireAsync(_data);
    }

    private static void DoHourly()
    {
    }

    private async void TimerCallbackAsync(object? state)
    {
        try
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);

            using var serviceScope = _serviceProvider.CreateScope();

            var _data = serviceScope.ServiceProvider.GetServiceOrThrow<IData>();

            try
            {
                var utcNow = DateTime.UtcNow;

                DoHourly();

                if (utcNow.Hour == 0)
                {
                    await DoDailyAsync(_data);
                }
            }
            catch (Exception exception)
            {
                await _business.Event.Exception.LogAsync(_data, exception);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }

        ChangeTimer();
    }
}
