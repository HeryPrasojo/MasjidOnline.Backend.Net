using MasjidOnline.Data.Interface.Initializer;

namespace MasjidOnline.Data.Interface;

public interface IDataInitializer
{
    IAccountancyInitializer Accountancy { get; }
    IAuditInitializer Audit { get; }
    IAuthorizationInitializer Authorization { get; }
    ICaptchaInitializer Captcha { get; }
    IEventInitializer Event { get; }
    IInfaqInitializer Infaq { get; }
    IPersonInitializer Person { get; }
    ISessionInitializer Session { get; }
    IUserInitializer User { get; }
}
