using System;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Entity.Audit;

public class PermissionLog : Permission
{
    public required int PermissionLogId { get; set; }

    public required int SessionUserId { get; set; }

    public required DateTime DateTime { get; set; }
}
