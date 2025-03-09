using System;

namespace MasjidOnline.Entity.Infaq;

public class Expire
{
    public required int Id { get; set; }

    public int InfaqId { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public required ExpireStatus Status { get; set; }

    public string? Description { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateUserId { get; set; }
}
