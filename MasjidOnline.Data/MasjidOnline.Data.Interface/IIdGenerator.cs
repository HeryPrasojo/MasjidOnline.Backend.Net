using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.Interface;

public interface IIdGenerator
{
    IAccountancyIdGenerator Accountancy { get; }
    IAuditIdGenerator Audit { get; }
    IAuthorizationIdGenerator Authorization { get; }
    IDatabaseTemplateIdGenerator DatabaseTemplate { get; }
    IEventIdGenerator Event { get; }
    IInfaqIdGenerator Infaq { get; }
    IPaymentIdGenerator Payment { get; }
    IPersonIdGenerator Person { get; }
    ISessionIdGenerator Session { get; }
    IUserIdGenerator User { get; }
}
