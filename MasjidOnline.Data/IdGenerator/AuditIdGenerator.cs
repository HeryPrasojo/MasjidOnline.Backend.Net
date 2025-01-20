using System;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.IdGenerator;

public class AuditIdGenerator : IAuditIdGenerator
{
    public AuditIdGenerator(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var auditData = serviceScope.ServiceProvider.GetService<IAuditData>()
            ?? throw new ApplicationException($"Get IAuditData service fail");
    }
}
