using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.Interface;

public interface IIdGenerator
{
    IAuditIdGenerator Audit { get; }
    IAuthorizationIdGenerator Authorization { get; }
    IPersonIdGenerator Person { get; }
    IEventIdGenerator Event { get; }
    IInfaqIdGenerator Infaq { get; }
    ISessionIdGenerator Session { get; }
    IUserIdGenerator User { get; }
}
