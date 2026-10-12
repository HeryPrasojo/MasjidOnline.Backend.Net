using System;

namespace MasjidOnline.Entity.Approval;

public class Approval
{
    public required int Id { get; set; }

    public ApprovalType Type { get; set; }
    public int TypeId { get; set; }

    public DateTime DateTime { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }

    public required int Step { get; set; }
    public required ApprovalStatus Status { get; set; }
}
