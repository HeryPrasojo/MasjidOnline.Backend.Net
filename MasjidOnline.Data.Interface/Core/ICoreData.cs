using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Core;

public interface ICoreData : IData
{

    ICoreSettingRepository CoreSetting { get; }

    Task<int> SaveAsync();
}
