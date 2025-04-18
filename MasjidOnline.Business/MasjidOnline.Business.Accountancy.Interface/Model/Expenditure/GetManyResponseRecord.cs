using System;

namespace MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;

public class GetManyResponseRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string? EmailAddress { get; set; }

    public required int UserId { get; set; }

    public required InternalStatus Status { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
