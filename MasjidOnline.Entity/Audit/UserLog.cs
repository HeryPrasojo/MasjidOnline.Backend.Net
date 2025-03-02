using System;

namespace MasjidOnline.Entity.Audit;

public class UserLog : Entity.User.User
{
    public required int UserLogId { get; set; }

    public required int SessionUserId { get; set; }

    public required DateTime DateTime { get; set; }
}
