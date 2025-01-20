using System;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Entity.Audit;

public class UserLog : User
{
    public required int UserLogId { get; set; }

    public required int SessionUserId { get; set; }

    public required DateTime DateTime { get; set; }
}
