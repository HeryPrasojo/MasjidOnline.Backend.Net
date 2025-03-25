using MasjidOnline.Data.Interface.Repository.Person;

namespace MasjidOnline.Data.Interface.Databases;

public interface IPersonDatabase : IDatabase
{
    IPersonSettingRepository PersonSetting { get; }
}
