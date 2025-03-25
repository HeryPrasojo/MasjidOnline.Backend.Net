using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Audit;

namespace MasjidOnline.Data.Initializer;

public abstract class AuditInitializer(IAuditDefinition _auditDefinition) : IAuditInitializer
{
    public async Task InitializeDatabaseAsync(IAuditDatabase auditDatabase)
    {
        var settingTableExists = await _auditDefinition.CheckTableExistsAsync(nameof(AuditSetting));

        if (!settingTableExists)
        {
            await CreateTableAuditSettingAsync();
            await CreateTablePermissionLogAsync();


            var auditSetting = new AuditSetting
            {
                Id = (int)AuditSettingId.DatabaseVersion,
                Description = nameof(AuditSettingId.DatabaseVersion),
                Value = "1",
            };

            await auditDatabase.AuditSetting.AddAsync(auditSetting);

            await auditDatabase.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableAuditSettingAsync();
    protected abstract Task<int> CreateTablePermissionLogAsync();
}
