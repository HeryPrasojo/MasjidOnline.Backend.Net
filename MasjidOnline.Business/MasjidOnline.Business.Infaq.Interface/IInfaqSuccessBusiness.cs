using MasjidOnline.Business.Infaq.Interface.Success;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqSuccessBusiness
{
    IAddBusiness Add { get; }
    IApproveBusiness Approve { get; }
    ICancelBusiness Cancel { get; }
    IGetManyBusiness GetMany { get; }
    IGetManyNewBusiness GetManyNew { get; }
    IGetOneBusiness GetOne { get; }
    IGetOneNewBusiness GetOneNew { get; }
    IRejectBusiness Reject { get; }
}
