using MasjidOnline.Data.IdGenerators;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Data;

public class IdGenerator(IHash512Service _hash512Service) : IIdGenerator
{
    public IAuditIdGenerator Audit { get; } = new AuditIdGenerator();
    public IPersonIdGenerator Person { get; } = new PersonIdGenerator();
    public ICaptchaIdGenerator Captcha { get; } = new CaptchaIdGenerator();
    public IEventIdGenerator Event { get; } = new EventIdGenerator();
    public IInfaqIdGenerator Infaq { get; } = new InfaqIdGenerator();
    public ISessionIdGenerator Session { get; } = new SessionIdGenerator(_hash512Service);
    public IUserIdGenerator User { get; } = new UserIdGenerator(_hash512Service);
}
