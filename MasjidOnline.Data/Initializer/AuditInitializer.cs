using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Audit;

namespace MasjidOnline.Data.Initializer;

public abstract class AuditInitializer(IAuditData _auditData, IAuditDefinition _auditDefinition) : IAuditInitializer
{
    public async Task InitializeDatabaseAsync()
    {
        var settingTableExists = await _auditDefinition.CheckTableExistsAsync("AuditSetting");

        if (!settingTableExists)
        {
            await CreateTableAuditSettingAsync();

            var auditSetting = new AuditSetting
            {
                Key = AuditSettingKey.DatabaseVersion,
                Value = "1",
            };

            await _auditData.AuditSetting.AddAsync(auditSetting);

            await _auditData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableAuditSettingAsync();
}
