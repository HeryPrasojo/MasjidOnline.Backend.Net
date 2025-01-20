using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteAuditInitializer(
    AuditDataContext _auditDataContext,
    IAuditData _auditData,
    IAuditDefinition _auditDefinition) : AuditInitializer(_auditData, _auditDefinition)
{
    protected override async Task<int> CreateTableAuditSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE AuditSetting
            (
                Key TEXT PRIMARY KEY,
                Value TEXT NOT NULL
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }
}
