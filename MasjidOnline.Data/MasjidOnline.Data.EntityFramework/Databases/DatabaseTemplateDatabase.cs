using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.DatabaseTemplate;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Database;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class DatabaseTemplateDatabase(
    DatabaseTemplateDataContext _databaseTemplateDataContext) : Database(_databaseTemplateDataContext), IDatabaseTemplateDatabase
{
    private IDatabaseSettingRepository? _databaseSettingRepository;
    private ITableRepository? _userInternalPermissionLogRepository;

    public IDatabaseSettingRepository DatabaseSetting => _databaseSettingRepository ??= new DatabaseTemplateSettingRepository(_databaseTemplateDataContext);
    public ITableRepository Table => _userInternalPermissionLogRepository ??= new TableTemplateRepository(_databaseTemplateDataContext);
}