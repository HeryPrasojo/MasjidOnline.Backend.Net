using System;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Databases;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data;

public abstract class Data(IServiceProvider _serviceProvider) : IData
{
    private IDataTransaction? _dataTransaction;

    public IDataTransaction Transaction => _dataTransaction ??= GetService<IDataTransaction>();

    public abstract IAuditDatabase Audit { get; }
    public abstract IData Captcha { get; }
    public abstract IEventDatabase Event { get; }
    public abstract IData Infaq { get; }
    public abstract IPersonDatabase Person { get; }
    public abstract IData Session { get; }
    public abstract IData User { get; }

    protected TService GetService<TService>()
    {
        return _serviceProvider.GetService<TService>() ?? throw new ApplicationException($"Get {typeof(TService).Name} service fail");
    }
}
