using MasjidOnline.Data.Interface.Repository.Core;

namespace MasjidOnline.Data.Interface.Datas;

public interface ICoreData : IData
{
    ICoreSettingRepository CoreSetting { get; }
}
