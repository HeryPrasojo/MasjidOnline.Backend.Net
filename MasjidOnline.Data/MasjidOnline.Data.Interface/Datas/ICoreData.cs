using MasjidOnline.Data.Interface.Repository.Core;

namespace MasjidOnline.Data.Interface.Datas;

public interface ICoreData : IDataWithoutAudit
{
    ICoreSettingRepository CoreSetting { get; }
}
