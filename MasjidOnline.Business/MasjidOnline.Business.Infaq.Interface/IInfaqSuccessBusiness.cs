using MasjidOnline.Business.Infaq.Interface.Success;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqSuccessBusiness
{
    IAddBusiness Add { get; }
    IApproveBusiness Approve { get; }
    ICancelBusiness Cancel { get; }
    IGetManyBusiness GetMany { get; }
    IGetOneBusiness GetOne { get; }
    IRejectBusiness Reject { get; }
}
