using MasjidOnline.Data.Interface.Repository.Infaqs;

namespace MasjidOnline.Data.Interface.Datas;

public interface IInfaqsData : IDataWithoutAudit
{
    IInfaqRepository Infaq { get; }
    IInfaqFileRepository InfaqFile { get; }
    IInfaqManualRepository InfaqManual { get; }
    IInfaqSettingRepository InfaqSetting { get; }
    IExpiredRepository Expired { get; }
}
