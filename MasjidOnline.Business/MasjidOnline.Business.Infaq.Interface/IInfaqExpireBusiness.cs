using MasjidOnline.Business.Infaq.Interface.Expire;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqExpireBusiness
{
    IAddBusiness Add { get; }
    IApproveBusiness Approve { get; }
    ICancelBusiness Cancel { get; }
    IGetManyBusiness GetMany { get; }
    IGetOneBusiness GetOne { get; }
    IRejectBusiness Reject { get; }
}
