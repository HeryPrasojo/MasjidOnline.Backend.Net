using System;

namespace MasjidOnline.Entity.Approval;

public class ApprovalStep
{
    public required int Id { get; set; }
    public required int ApprovalId { get; set; }

    public required int Step { get; set; }
    public required DateTime DateTime { get; set; }
    public required int UserId { get; set; }
    public required ApprovalStatus Status { get; set; }
    public string? Description { get; set; }
}
