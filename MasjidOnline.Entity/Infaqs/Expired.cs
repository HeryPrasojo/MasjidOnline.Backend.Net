using System;

namespace MasjidOnline.Entity.Infaqs;

public class Expired
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateUserId { get; set; }

    public bool? IsApproved { get; set; }
}
