using System;
using MasjidOnline.Entity.Accountancy;

namespace MasjidOnline.Data.Interface.ViewModel.Accountancy.Expenditure;

public class ManyRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public required string Description { get; set; }

    public required decimal Amount { get; set; }

    public required ExpenditureStatus Status { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
