using MasjidOnline.Data.Interface.Initializer;

namespace MasjidOnline.Data.Interface;

public interface IDataInitializer
{
    IAccountancyInitializer Accountancy { get; }
    IAuditInitializer Audit { get; }
    IAuthorizationInitializer Authorization { get; }
    ICaptchaInitializer Captcha { get; }
    IDatabaseTemplateInitializer DatabaseTemplate { get; }
    IEventInitializer Event { get; }
    IInfaqInitializer Infaq { get; }
    IPaymentInitializer Payment { get; }
    IPersonInitializer Person { get; }
    ISessionInitializer Session { get; }
    IUserInitializer User { get; }
}
