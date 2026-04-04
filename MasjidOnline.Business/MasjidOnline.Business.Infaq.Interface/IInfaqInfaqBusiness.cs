using MasjidOnline.Business.Infaq.Interface.Infaq;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqInfaqBusiness
{
    IAddBusiness Add { get; }
    IGetTableBusiness GetTable { get; }
    IGetViewBusiness GetView { get; }
}
