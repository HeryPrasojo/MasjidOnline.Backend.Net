using System;

namespace MasjidOnline.Data.Interface.Model.Infaq.Expired;

public class One
{
    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public required bool? IsApproved { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
