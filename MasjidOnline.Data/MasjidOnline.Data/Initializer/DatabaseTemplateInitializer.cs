using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.DatabaseTemplate;

namespace MasjidOnline.Data.Initializer;

public abstract class DatabaseTemplateInitializer(IDatabaseTemplateDefinition _databaseTemplateDefinition) : IDatabaseTemplateInitializer
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
                Id = (int)DatabaseTemplateSettingId.DatabaseVersion,
                Description = nameof(DatabaseTemplateSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.DatabaseTemplate.DatabaseTemplateSetting.AddAsync(databaseSetting);

            await data.DatabaseTemplate.SaveAsync();
        }
    }

    protected abstract Task<int> CreateTableDatabaseTemplateSettingAsync();
    protected abstract Task<int> CreateTableTableTemplateAsync();
}
