using MasjidOnline.Business.Accountancy.Interface.Expenditure;

namespace MasjidOnline.Business.Accountancy.Interface;

public interface IAccountancyExpenditureBusiness
{
    IAddBusiness Add { get; }
    IApproveBusiness Approve { get; }
    ICancelBusiness Cancel { get; }
    IGetManyBusiness GetMany { get; }
    IGetViewBusiness GetView { get; }
    IRejectBusiness Reject { get; }
}
