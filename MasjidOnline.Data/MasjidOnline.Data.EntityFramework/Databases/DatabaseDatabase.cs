using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Database;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Database;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class DatabaseDatabase(
    DatabaseDataContext _databaseDataContext) : Database(_databaseDataContext), IDatabaseDatabase
{
    private IDatabaseSettingRepository? _databaseSettingRepository;
    private ITableRepository? _userInternalPermissionLogRepository;

    public IDatabaseSettingRepository DatabaseSetting => _databaseSettingRepository ??= new DatabaseSettingRepository(_databaseDataContext);
    public ITableRepository Table => _userInternalPermissionLogRepository ??= new TableRepository(_databaseDataContext);
}