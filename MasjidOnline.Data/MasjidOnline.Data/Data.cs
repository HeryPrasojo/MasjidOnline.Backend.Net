using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data;

public abstract class Data() : IData
{
    private IDataTransaction? _dataTransaction;

    public IDataTransaction Transaction => _dataTransaction ??= new DataTransaction();

    public abstract IAccountancyDatabase Accountancy { get; }
    public abstract IAuditDatabase Audit { get; }
    public abstract IAuthorizationDatabase Authorization { get; }
    public abstract ICaptchaDatabase Captcha { get; }
    public abstract IDatabaseDatabase Database { get; }
    public abstract IEventDatabase Event { get; }
    public abstract IInfaqDatabase Infaq { get; }
    public abstract IPersonDatabase Person { get; }
    public abstract ISessionDatabase Session { get; }
    public abstract IUserDatabase User { get; }
}
