using MasjidOnline.Entity.Accountancy;

namespace MasjidOnline.Data.Interface.ViewModel.Accountancy.Expenditure;

public class ForApprove
{
    public required string Description { get; set; }

    public required decimal Amount { get; set; }

    public required ExpenditureStatus Status { get; set; }
}
