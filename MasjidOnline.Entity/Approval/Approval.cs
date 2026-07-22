using System;

namespace MasjidOnline.Entity.Approval;

public class Approval
{
    public required int Id { get; set; }

    public required ApprovalType Type { get; set; }
    public required int TypeId { get; set; }

    public required DateTime DateTime { get; set; }
    public required int UserId { get; set; }
    public string? Description { get; set; }

    public required int Step { get; set; }
    public required ApprovalStatus Status { get; set; }
}
