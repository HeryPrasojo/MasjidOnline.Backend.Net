using MasjidOnline.Data.Interface.Repository.Infaq;

namespace MasjidOnline.Data.Interface.Datas;

public interface IInfaqData : IDataWithoutAudit
{
    IInfaqRepository Infaq { get; }
    IInfaqFileRepository InfaqFile { get; }
    IInfaqManualRepository InfaqManual { get; }
    IInfaqSettingRepository InfaqSetting { get; }
    IExpiredRepository Expired { get; }
    IPaymentRepository Payment { get; }
}
