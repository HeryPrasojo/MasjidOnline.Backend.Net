using System;

namespace MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;

public class GetManyNewResponseRecord
{
    public required DateTime DateTime { get; set; }

    public string EmailAddress { get; set; } = default!;

    public required int UserId { get; set; }

    public string? Description { get; set; }
}
