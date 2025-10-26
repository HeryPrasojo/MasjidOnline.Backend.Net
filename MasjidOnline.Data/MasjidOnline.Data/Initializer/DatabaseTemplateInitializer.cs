using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.DatabaseTemplate;

namespace MasjidOnline.Data.Initializer;

public abstract class DatabaseTemplateInitializer(IDatabaseTemplateDefinition _databaseTemplateDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _databaseTemplateDefinition.CheckTableExistsAsync(nameof(DatabaseTemplateSetting));

        if (!settingTableExists)
        {
            await CreateTableDatabaseTemplateSettingAsync();
            await CreateTableTableTemplateAsync();


            var databaseSetting = new DatabaseTemplateSetting
            {
                Id = DatabaseTemplateSettingId.DatabaseVersion,
                Description = nameof(DatabaseTemplateSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.DatabaseTemplate.DatabaseTemplateSetting.AddAndSaveAsync(databaseSetting);
        }
    }

    protected abstract Task CreateTableDatabaseTemplateSettingAsync();
    protected abstract Task CreateTableTableTemplateAsync();
}
