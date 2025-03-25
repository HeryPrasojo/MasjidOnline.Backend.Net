using MasjidOnline.Data.Interface.Repository.Person;

namespace MasjidOnline.Data.Interface.Datas;

public interface IPersonDatabase : IData
{
    IPersonSettingRepository PersonSetting { get; }
}
