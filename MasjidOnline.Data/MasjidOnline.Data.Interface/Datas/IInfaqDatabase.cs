using MasjidOnline.Data.Interface.Repository.Infaq;

namespace MasjidOnline.Data.Interface.Datas;

public interface IInfaqDatabase : IData
{
    IInfaqRepository Infaq { get; }
    IInfaqFileRepository InfaqFile { get; }
    IInfaqManualRepository InfaqManual { get; }
    IInfaqSettingRepository InfaqSetting { get; }
    IExpireRepository Expire { get; }
    IPaymentRepository Payment { get; }
    ISuccessRepository Success { get; }
    IVoidRepository Void { get; }
}
