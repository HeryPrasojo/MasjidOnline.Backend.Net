using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Audit;

namespace MasjidOnline.Data.Initializer;

public abstract class AuditInitializer(IAuditDefinition _auditDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _auditDefinition.CheckTableExistsAsync(nameof(AuditSetting));

        if (!settingTableExists)
        {
            await CreateTableAuditSettingAsync();
            await CreateTableUserLogAsync();
            await CreateTableUserEmailAddressLogAsync();
            await CreateTableUserInternalPermissionLogAsync();


            var auditSetting = new AuditSetting
            {
                Id = (int)AuditSettingId.DatabaseVersion,
                Description = nameof(AuditSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Audit.AuditSetting.AddAndSaveAsync(auditSetting);
        }
    }


    protected abstract Task CreateTableAuditSettingAsync();
    protected abstract Task CreateTableUserLogAsync();
    protected abstract Task CreateTableUserEmailAddressLogAsync();
    protected abstract Task CreateTableUserInternalPermissionLogAsync();
}
