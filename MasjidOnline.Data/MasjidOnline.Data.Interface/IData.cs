using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface;

public interface IData
{
    IDataTransaction Transaction { get; }

    IAccountancyDatabase Accountancy { get; }
    IAuditDatabase Audit { get; }
    IAuthorizationDatabase Authorization { get; }
    ICaptchaDatabase Captcha { get; }
    IEventDatabase Event { get; }
    IInfaqDatabase Infaq { get; }
    IIdGenerator IdGenerator { get; }
    IPaymentDatabase Payment { get; }
    IPersonDatabase Person { get; }
    ISessionDatabase Session { get; }
    IUserDatabase User { get; }
    IVerificationDatabase Verification { get; }
}
