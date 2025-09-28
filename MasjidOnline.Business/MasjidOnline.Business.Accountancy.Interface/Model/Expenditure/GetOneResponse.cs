using System;

namespace MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;

public class GetOneResponse
{
    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public ExpenditureStatus Status { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
