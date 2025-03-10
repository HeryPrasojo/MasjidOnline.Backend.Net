// undone
using System;

namespace MasjidOnline.Entity.Infaq;

public class Success
{
    public required int Id { get; set; }

    public int InfaqId { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public required SuccessStatus Status { get; set; }

    public string? Description { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateUserId { get; set; }
}
