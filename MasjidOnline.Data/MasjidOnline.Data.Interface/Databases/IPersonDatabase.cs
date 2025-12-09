using MasjidOnline.Data.Interface.Repository.Person;

namespace MasjidOnline.Data.Interface.Databases;

public interface IPersonDatabase : IDatabase
{
    IPersonRepository Person { get; }
    IPersonSettingRepository PersonSetting { get; }
}
