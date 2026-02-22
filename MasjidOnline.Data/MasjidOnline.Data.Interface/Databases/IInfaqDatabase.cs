using MasjidOnline.Data.Interface.Repository.Infaq;

namespace MasjidOnline.Data.Interface.Databases;

public interface IInfaqDatabase : IDatabase
{
    IInfaqRepository Infaq { get; }
    IInfaqSettingRepository InfaqSetting { get; }
}
