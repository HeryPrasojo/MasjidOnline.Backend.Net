using System;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.EntityFramework;

public class EntityFrameworkData(IServiceProvider _serviceProvider) : Data(_serviceProvider)
{
    private IAuditDatabase? _auditDatabase;
    private IData? _data;
    private IEventDatabase? _eventDatabase;
    private IData? _data;
    private IPersonDatabase? _personDatabase;
    private IData? _data;
    private IData? _data;

    public override IAuditDatabase Audit => _auditDatabase ??= GetService<IAuditDatabase>();
    public override IData Captcha => _data ??= GetService<IData>();
    public override IEventDatabase Event => _eventDatabase ??= GetService<IEventDatabase>();
    public override IData Infaq => _data ??= GetService<IData>();
    public override IPersonDatabase Person => _personDatabase ??= GetService<IPersonDatabase>();
    public override IData Session => _data ??= GetService<IData>();
    public override IData User => _data ??= GetService<IData>();
}
