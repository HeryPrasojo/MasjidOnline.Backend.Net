using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.SqLite.Initializer;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Initializer;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class DataInitializer(
    AuditDataContext _auditDataContext,
    AuthorizationDataContext _authorizationDataContext,
    CaptchaDataContext _captchaDataContext,
    EventDataContext _eventDataContext,
    InfaqDataContext _infaqDataContext,
    PersonDataContext _personDataContext,
    SessionDataContext _sessionDataContext,
    UserDataContext _userDataContext
    ) : IDataInitializer
{
    private IAuditInitializer? _auditInitializer;
    private IAuthorizationInitializer? _authorizationInitializer;
    private ICaptchaInitializer? _captchaInitializer;
    private IEventInitializer? _eventInitializer;
    private IInfaqInitializer? _infaqInitializer;
    private IPersonInitializer? _personInitializer;
    private ISessionInitializer? _sessionInitializer;
    private IUserInitializer? _userInitializer;

    public IAuditInitializer Audit => _auditInitializer ??= new AuditInitializer(_auditDataContext, new DataDefinition<AuditDataContext>(_auditDataContext));
    public IAuthorizationInitializer Authorization => _authorizationInitializer ??= new AuthorizationInitializer(_authorizationDataContext, new DataDefinition<AuthorizationDataContext>(_authorizationDataContext));
    public ICaptchaInitializer Captcha => _captchaInitializer ??= new CaptchaInitializer(_captchaDataContext, new DataDefinition<CaptchaDataContext>(_captchaDataContext));
    public IEventInitializer Event => _eventInitializer ??= new EventInitializer(_eventDataContext, new DataDefinition<EventDataContext>(_eventDataContext));
    public IInfaqInitializer Infaq => _infaqInitializer ??= new InfaqInitializer(_infaqDataContext, new DataDefinition<InfaqDataContext>(_infaqDataContext));
    public IPersonInitializer Person => _personInitializer ??= new PersonInitializer(_personDataContext, new DataDefinition<PersonDataContext>(_personDataContext));
    public ISessionInitializer Session => _sessionInitializer ??= new SessionInitializer(_sessionDataContext, new DataDefinition<SessionDataContext>(_sessionDataContext));
    public IUserInitializer User => _userInitializer ??= new UserInitializer(_userDataContext, new DataDefinition<UserDataContext>(_userDataContext));
}
