using MasjidOnline.Business.User.Interface.Internal;

namespace MasjidOnline.Business.User.Interface;

public interface IUserInternalBusiness
{
    public IAddBusiness Add { get; }
    public IApproveBusiness Approve { get; }
    public ICancelBusiness Cancel { get; }
    public IGetTableBusiness GetTable { get; }
    public IGetViewBusiness GetView { get; }
    public IRejectBusiness Reject { get; }
}
