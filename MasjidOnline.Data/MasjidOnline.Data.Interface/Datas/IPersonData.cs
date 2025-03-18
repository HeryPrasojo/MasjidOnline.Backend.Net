using MasjidOnline.Data.Interface.Repository.Person;

namespace MasjidOnline.Data.Interface.Datas;

public interface IPersonData : IData
{
    IPersonSettingRepository PersonSetting { get; }
}
