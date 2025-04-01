using MasjidOnline.Business.Infaq.Interface.Expire;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqExpireBusiness
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
