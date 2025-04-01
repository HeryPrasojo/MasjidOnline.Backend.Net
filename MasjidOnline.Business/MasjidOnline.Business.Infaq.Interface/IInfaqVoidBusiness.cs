using MasjidOnline.Business.Infaq.Interface.Void;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqVoidBusiness
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
