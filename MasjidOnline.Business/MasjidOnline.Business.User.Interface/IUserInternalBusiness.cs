using MasjidOnline.Business.User.Interface.Internal;

namespace MasjidOnline.Business.User.Interface;

public interface IUserInternalBusiness
{
    public IAddBusiness Add { get; }
    public IApproveBusiness Approve { get; }
    public ICancelBusiness Cancel { get; }
    public IGetManyBusiness GetMany { get; }
    public IGetOneBusiness GetOne { get; }
    public IRejectBusiness Reject { get; }
}
