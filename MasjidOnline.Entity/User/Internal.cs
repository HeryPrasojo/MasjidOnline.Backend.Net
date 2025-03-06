using System;

namespace MasjidOnline.Entity.User;

public class Internal
{
    public required int Id { get; set; }

    public DateTime DateTime { get; set; }

    public string EmailAddress { get; set; } = default!;

    public int UserId { get; set; }

    public required InternalStatus Status { get; set; }

    public string? Description { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateUserId { get; set; }
}
