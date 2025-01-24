using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Audit;

namespace MasjidOnline.Data.Initializer;

public abstract class AuditInitializer(IAuditDefinition _auditDefinition) : IAuditInitializer
{
    public async Task InitializeDatabaseAsync(IAuditData auditData)
    {
        var settingTableExists = await _auditDefinition.CheckTableExistsAsync("AuditSetting");

        if (!settingTableExists)
        {
            await CreateTableAuditSettingAsync();
            await CreateTableUserLogAsync();
            await CreateTableUserEmailAddressLogAsync();


            var auditSetting = new AuditSetting
            {
                Key = AuditSettingKey.DatabaseVersion,
                Value = "1",
            };

            await auditData.AuditSetting.AddAsync(auditSetting);

            await auditData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableAuditSettingAsync();
    protected abstract Task<int> CreateTableUserLogAsync();
    protected abstract Task<int> CreateTableUserEmailAddressLogAsync();
}
