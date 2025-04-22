using MasjidOnline.Data.Interface.Repository.Database;

namespace MasjidOnline.Data.Interface.Databases;

public interface IDatabaseDatabase : IDatabase
{
    IDatabaseSettingRepository DatabaseSetting { get; }

    ITableRepository Table { get; }
}
