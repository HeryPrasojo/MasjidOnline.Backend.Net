using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.DatabaseTemplate;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.DatabaseTemplate;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class DatabaseTemplateDatabase(
    DatabaseTemplateDataContext _databaseTemplateDataContext) : Database(_databaseTemplateDataContext), IDatabaseTemplateDatabase
{
    private IDatabaseTemplateSettingRepository? _databaseTemplateSettingRepository;
    private ITableTemplateRepository? _tableTemplateRepository;

    public IDatabaseTemplateSettingRepository DatabaseTemplateSetting => _databaseTemplateSettingRepository ??= new DatabaseTemplateSettingRepository(_databaseTemplateDataContext);
    public ITableTemplateRepository TableTemplate => _tableTemplateRepository ??= new TableTemplateRepository(_databaseTemplateDataContext);
}