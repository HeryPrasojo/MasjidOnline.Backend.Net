using System;

namespace MasjidOnline.Entity.Accountancy;

public class Expenditure
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public required string Description { get; set; }

    public required decimal Amount { get; set; }

    public required ExpenditureStatus Status { get; set; }

    public string? StatusDescription { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateUserId { get; set; }
}
