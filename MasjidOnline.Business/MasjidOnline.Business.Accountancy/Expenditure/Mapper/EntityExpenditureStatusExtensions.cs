
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Accountancy.Expenditure.Mapper;

// todo move to Mapper project
public static class EntityExpenditureStatusExtensions
{
    public static Interface.Model.Expenditure.ExpenditureStatus ToModel(this Entity.Accountancy.ExpenditureStatus internalStatus)
    {
        return internalStatus switch
        {
            Entity.Accountancy.ExpenditureStatus.Approve
                => Interface.Model.Expenditure.ExpenditureStatus.Approve,

            Entity.Accountancy.ExpenditureStatus.Cancel
                => Interface.Model.Expenditure.ExpenditureStatus.Cancel,

            Entity.Accountancy.ExpenditureStatus.New
                => Interface.Model.Expenditure.ExpenditureStatus.New,

            Entity.Accountancy.ExpenditureStatus.Reject
                => Interface.Model.Expenditure.ExpenditureStatus.Reject,

            _ => throw new ErrorException(nameof(internalStatus)),
        };
    }
}
