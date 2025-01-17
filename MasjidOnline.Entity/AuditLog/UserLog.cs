using System;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Entity.AuditLog;

public class UserLog : User
{
    public override required int Id { get; set; }

    public required int UserId { get => base.Id; set => base.Id = value; }


    public required int SessionUserId { get; set; }

    public required DateTime DateTime { get; set; }
}
