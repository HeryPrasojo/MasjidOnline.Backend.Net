using MasjidOnline.Data.EntityFramework.Databases;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.EntityFramework;

public class EntityFrameworkData(
    AuditDataContext _auditDataContext,
    CaptchaDataContext _captchaDataContext,
    EventDataContext _eventDataContext,
    InfaqDataContext _infaqDataContext,
    PersonDataContext _personDataContext,
    SessionDataContext _sessionDataContext,
    UserDataContext _userDataContext,
    IIdGenerator _idGenerator) : Data()
{
    private IAuditDatabase? _auditDatabase;
    private ICaptchaDatabase? _captchaData;
    private IEventDatabase? _eventDatabase;
    private IInfaqDatabase? _infaqData;
    private IPersonDatabase? _personDatabase;
    private ISessionDatabase? _sessionData;
    private IUserDatabase? _userData;

    public override IAuditDatabase Audit => _auditDatabase ??= new AuditDatabase(_auditDataContext, _idGenerator.Audit);
    public override ICaptchaDatabase Captcha => _captchaData ??= new CaptchaDatabase(_captchaDataContext);
    public override IEventDatabase Event => _eventDatabase ??= new EventDatabase(_eventDataContext);
    public override IInfaqDatabase Infaq => _infaqData ??= new InfaqDatabase(_infaqDataContext);
    public override IPersonDatabase Person => _personDatabase ??= new PersonDatabase(_personDataContext);
    public override ISessionDatabase Session => _sessionData ??= new SessionDatabase(_sessionDataContext);
    public override IUserDatabase User => _userData ??= new UserDatabase(_userDataContext);
}
