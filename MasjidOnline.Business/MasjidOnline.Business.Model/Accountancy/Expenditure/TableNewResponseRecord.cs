using System;

namespace MasjidOnline.Business.Model.Accountancy.Expenditure;

public class TableNewResponseRecord
{
    public required DateTime DateTime { get; set; }

    public string EmailAddress { get; set; } = default!;

    public required int UserId { get; set; }

    public string? Description { get; set; }
}
