using System;

namespace MasjidOnline.Entity.Accountancy;

public class Expenditure
{
    public required int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public string Description { get; set; } = default!;

    public decimal Amount { get; set; }

    public required ExpenditureStatus Status { get; set; }

    public string? StatusDescription { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateUserId { get; set; }
}
