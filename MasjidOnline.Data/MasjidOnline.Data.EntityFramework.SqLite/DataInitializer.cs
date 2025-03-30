using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.SqLite.Initializer;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Initializer;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class DataInitializer(
    AuditDataContext _auditDataContext,
    CaptchaDataContext _captchaDataContext,
    EventDataContext _eventDataContext,
    InfaqDataContext _infaqDataContext,
    PersonDataContext _personDataContext,
    SessionDataContext _sessionDataContext,
    UserDataContext _userDataContext
    ) : IDataInitializer
{
    private IAuditInitializer? _auditInitializer;
    private ICaptchaInitializer? _captchaInitializer;
    private IEventInitializer? _eventInitializer;
    private IInfaqInitializer? _infaqInitializer;
    private IPersonInitializer? _personInitializer;
    private ISessionInitializer? _sessionInitializer;
    private IUserInitializer? _userInitializer;

    public IAuditInitializer Audit => _auditInitializer ??= new SqLiteAuditInitializer(_auditDataContext, new SqLiteDefinition<AuditDataContext>(_auditDataContext));
    public ICaptchaInitializer Captcha => _captchaInitializer ??= new SqLiteCaptchaInitializer(_captchaDataContext, new SqLiteDefinition<CaptchaDataContext>(_captchaDataContext));
    public IEventInitializer Event => _eventInitializer ??= new SqLiteEventInitializer(_eventDataContext, new SqLiteDefinition<EventDataContext>(_eventDataContext));
    public IInfaqInitializer Infaq => _infaqInitializer ??= new SqLiteInfaqInitializer(_infaqDataContext, new SqLiteDefinition<InfaqDataContext>(_infaqDataContext));
    public IPersonInitializer Person => _personInitializer ??= new SqLitePersonInitializer(_personDataContext, new SqLiteDefinition<PersonDataContext>(_personDataContext));
    public ISessionInitializer Session => _sessionInitializer ??= new SqLiteSessionInitializer(_sessionDataContext, new SqLiteDefinition<SessionDataContext>(_sessionDataContext));
    public IUserInitializer User => _userInitializer ??= new SqLiteUserInitializer(_userDataContext, new SqLiteDefinition<UserDataContext>(_userDataContext));
}
