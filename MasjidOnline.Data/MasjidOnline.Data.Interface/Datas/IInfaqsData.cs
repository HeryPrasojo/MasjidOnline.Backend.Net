using MasjidOnline.Data.Interface.Repository.Infaqs;

namespace MasjidOnline.Data.Interface.Datas;

public interface IInfaqsData : IDataWithoutAudit
{
    IInfaqRepository Infaq { get; }
    IInfaqSettingRepository InfaqSetting { get; }
    IInfaqFileRepository InfaqFile { get; }
}
