using MasjidOnline.Business.Infaq.Interface.Void;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqVoidBusiness
{
    IAddBusiness Add { get; }
    IApproveBusiness Approve { get; }
    ICancelBusiness Cancel { get; }
    IGetManyBusiness GetMany { get; }
    IGetOneBusiness GetOne { get; }
    IRejectBusiness Reject { get; }
}
