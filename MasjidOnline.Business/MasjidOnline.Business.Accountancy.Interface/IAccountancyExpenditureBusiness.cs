using MasjidOnline.Business.Accountancy.Interface.Expenditure;

namespace MasjidOnline.Business.Accountancy.Interface;

public interface IAccountancyExpenditureBusiness
{
    IAddBusiness Add { get; }
    IApproveBusiness Approve { get; }
    ICancelBusiness Cancel { get; }
    IGetManyBusiness GetMany { get; }
    IGetOneBusiness GetOne { get; }
    IRejectBusiness Reject { get; }
}
