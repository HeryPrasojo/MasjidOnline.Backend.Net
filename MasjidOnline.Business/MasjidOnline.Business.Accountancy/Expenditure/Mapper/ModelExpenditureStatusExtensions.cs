using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Accountancy.Expenditure.Mapper;

public static class ModelExpenditureStatusExtensions
{
    public static Entity.Accountancy.ExpenditureStatus? ToEntity(this Interface.Model.Expenditure.ExpenditureStatus? internalStatus)
    {
        return internalStatus switch
        {
            Interface.Model.Expenditure.ExpenditureStatus.Approve
                => Entity.Accountancy.ExpenditureStatus.Approve,

            Interface.Model.Expenditure.ExpenditureStatus.Cancel
                => Entity.Accountancy.ExpenditureStatus.Cancel,

            Interface.Model.Expenditure.ExpenditureStatus.New
                => Entity.Accountancy.ExpenditureStatus.New,

            Interface.Model.Expenditure.ExpenditureStatus.Reject
                => Entity.Accountancy.ExpenditureStatus.Reject,

            null => default,

            _ => throw new ErrorException(nameof(internalStatus)),
        };
    }
}
