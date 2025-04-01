namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqBusiness
{
    IInfaqExpireBusiness Expire { get; }
    IInfaqInfaqBusiness Infaq { get; }
    IInfaqSuccessBusiness Success { get; }
    IInfaqVoidBusiness Void { get; }
}
