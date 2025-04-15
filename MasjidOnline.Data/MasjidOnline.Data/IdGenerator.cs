using MasjidOnline.Data.IdGenerators;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Data;

public class IdGenerator(IService _service) : IIdGenerator
{
    public IAccountancyIdGenerator Accountancy { get; } = new AccountancyIdGenerator();
    public IAuditIdGenerator Audit { get; } = new AuditIdGenerator();
    public IAuthorizationIdGenerator Authorization { get; } = new AuthorizationIdGenerator();
    public IPersonIdGenerator Person { get; } = new PersonIdGenerator();
    public IEventIdGenerator Event { get; } = new EventIdGenerator();
    public IInfaqIdGenerator Infaq { get; } = new InfaqIdGenerator();
    public ISessionIdGenerator Session { get; } = new SessionIdGenerator(_service.Hash512);
    public IUserIdGenerator User { get; } = new UserIdGenerator(_service.Hash512);
}
