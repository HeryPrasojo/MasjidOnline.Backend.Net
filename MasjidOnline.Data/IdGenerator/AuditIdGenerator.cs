using System;
using System.Threading;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.IdGenerator;

public class AuditIdGenerator : IAuditIdGenerator
{
    private int _userLogId;
    private int _userEmailAddressLogId;

    public AuditIdGenerator(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var auditData = serviceScope.ServiceProvider.GetService<IAuditData>()
            ?? throw new ApplicationException($"Get IAuditData service fail");

        _userLogId = auditData.UserLog.GetMaxIdAsync().Result;

        _userEmailAddressLogId = auditData.UserEmailAddressLog.GetMaxIdAsync().Result;
    }

    public int UserLogId => Interlocked.Increment(ref _userLogId);

    public int UserEmailAddressLogId => Interlocked.Increment(ref _userEmailAddressLogId);
}
