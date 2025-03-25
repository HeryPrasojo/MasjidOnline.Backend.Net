using MasjidOnline.Data.Interface.Repository.Person;

namespace MasjidOnline.Data.Interface.Databases;

public interface IPersonDatabase : IData
{
    IPersonSettingRepository PersonSetting { get; }
}
