using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data;

public class IdGenerator(
    IAuditIdGenerator _auditIdGenerator,
    IPersonIdGenerator _personIdGenerator,
    ICaptchaIdGenerator _captchaIdGenerator,
    IEventIdGenerator _eventIdGenerator,
    IInfaqIdGenerator _infaqIdGenerator,
    ISessionIdGenerator _sessionIdGenerator,
    IUserIdGenerator _userIdGenerator

    ) : IIdGenerator
{
    public IAuditIdGenerator Audit => _auditIdGenerator;
    public IPersonIdGenerator Person => _personIdGenerator;
    public ICaptchaIdGenerator Captcha => _captchaIdGenerator;
    public IEventIdGenerator Event => _eventIdGenerator;
    public IInfaqIdGenerator Infaq => _infaqIdGenerator;
    public ISessionIdGenerator Session => _sessionIdGenerator;
    public IUserIdGenerator User => _userIdGenerator;
}
