using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface;

public interface IData
{
    IDataTransaction Transaction { get; }

    IAuditDatabase Audit { get; }
    IAuthorizationDatabase Authorization { get; }
    ICaptchaDatabase Captcha { get; }
    IEventDatabase Event { get; }
    IInfaqDatabase Infaq { get; }
    IPersonDatabase Person { get; }
    ISessionDatabase Session { get; }
    IUserDatabase User { get; }
}
