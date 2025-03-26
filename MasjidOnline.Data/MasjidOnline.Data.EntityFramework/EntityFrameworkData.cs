using System;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.EntityFramework;

public class EntityFrameworkData(IServiceProvider _serviceProvider) : Data(_serviceProvider)
{
    private IAuditDatabase? _auditDatabase;
    private ICaptchaDatabase? _captchaData;
    private IEventDatabase? _eventDatabase;
    private IInfaqDatabase? _infaqData;
    private IPersonDatabase? _personDatabase;
    private ISessionDatabase? _sessionData;
    private IUserDatabase? _userData;

    public override IAuditDatabase Audit => _auditDatabase ??= GetService<IAuditDatabase>();
    public override ICaptchaDatabase Captcha => _captchaData ??= GetService<ICaptchaDatabase>();
    public override IEventDatabase Event => _eventDatabase ??= GetService<IEventDatabase>();
    public override IInfaqDatabase Infaq => _infaqData ??= GetService<IInfaqDatabase>();
    public override IPersonDatabase Person => _personDatabase ??= GetService<IPersonDatabase>();
    public override ISessionDatabase Session => _sessionData ??= GetService<ISessionDatabase>();
    public override IUserDatabase User => _userData ??= GetService<IUserDatabase>();
}
