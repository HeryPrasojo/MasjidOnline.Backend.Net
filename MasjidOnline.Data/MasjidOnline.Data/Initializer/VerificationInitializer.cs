using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Verification;

namespace MasjidOnline.Data.Initializer;

public abstract class VerificationInitializer(IVerificationDefinition _verificationDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _verificationDefinition.CheckTableExistsAsync(nameof(VerificationSetting));

        if (!settingTableExists)
        {
            await CreateTableVerificationSettingAsync();

            await CreateTableVerificationCodeAsync();


            var databaseSetting = new VerificationSetting
            {
                Id = VerificationSettingId.DatabaseVersion,
                Description = nameof(VerificationSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Verification.VerificationSetting.AddAndSaveAsync(databaseSetting);
        }
    }

    protected abstract Task CreateTableVerificationSettingAsync();

    protected abstract Task CreateTableVerificationCodeAsync();
}
