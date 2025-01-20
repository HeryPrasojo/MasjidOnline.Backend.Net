using System;
using System.Threading;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.IdGenerator;

public class EventIdGenerator : IEventIdGenerator
{
    private int _errorExceptionId;

    public EventIdGenerator(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var eventData = serviceScope.ServiceProvider.GetService<IEventData>()
            ?? throw new ApplicationException($"Get IEventData service fail");

        _errorExceptionId = eventData.Exception.GetMaxIdAsync().Result;
    }

    public int ExceptionId => Interlocked.Increment(ref _errorExceptionId);


}
