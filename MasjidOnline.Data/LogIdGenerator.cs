using System;
using System.Threading;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Log;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data;

public class LogIdGenerator : ILogIdGenerator
{
    private long _errorExceptionId;

    public LogIdGenerator(IServiceProvider serviceProvider)
    {
        using (var serviceScope = serviceProvider.CreateScope())
        {
            var logData = serviceScope.ServiceProvider.GetService<ILogData>()
           ?? throw new ApplicationException($"Get ILogData service fail");

            _errorExceptionId = logData.ErrorException.GetMaxIdAsync().Result;
        }
    }

    public long ErrorExceptionId => Interlocked.Increment(ref _errorExceptionId);


}
