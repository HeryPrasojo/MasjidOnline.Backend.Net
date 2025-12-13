using System;

namespace MasjidOnline.Entity.User;

public class InternalUser
{
    public required int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public required InternalUserStatus Status { get; set; }

    public required string? Description { get; set; }

    public int AddUserId { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateUserId { get; set; }
}
