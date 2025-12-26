using System;

namespace MasjidOnline.Business.Model.Accountancy.Expenditure;

public class GetOneNewResponse
{
    public required string EmailAddress { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
