using System;

namespace MasjidOnline.Entity.Users;

public class Internal
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string EmailAddress { get; set; }

    public required int UserId { get; set; }

    public bool? IsApproved { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateUserId { get; set; }
}
