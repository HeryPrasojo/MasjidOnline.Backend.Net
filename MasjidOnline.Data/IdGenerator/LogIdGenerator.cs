using System;
using System.Threading;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.IdGenerator;

public class LogIdGenerator : ILogIdGenerator
{
    private int _errorExceptionId;

    public LogIdGenerator(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var logData = serviceScope.ServiceProvider.GetService<ILogData>()
            ?? throw new ApplicationException($"Get ILogData service fail");

        _errorExceptionId = logData.Exception.GetMaxIdAsync().Result;
    }

    public int ErrorExceptionId => Interlocked.Increment(ref _errorExceptionId);


}
