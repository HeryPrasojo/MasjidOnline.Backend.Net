using MasjidOnline.Data.Interface.Repository.DatabaseTemplate;

namespace MasjidOnline.Data.Interface.Databases;

public interface IDatabaseTemplateDatabase : IDatabase
{
    IDatabaseTemplateSettingRepository DatabaseTemplateSetting { get; }

    ITableTemplateRepository TableTemplate { get; }
}
