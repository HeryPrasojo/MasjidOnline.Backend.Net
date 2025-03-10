using System;

namespace MasjidOnline.Entity.Infaq;

public class Void
{
    public required int Id { get; set; }

    public int InfaqId { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public required VoidStatus Status { get; set; }

    public string? Description { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateUserId { get; set; }
}
