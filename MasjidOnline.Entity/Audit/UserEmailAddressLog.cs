using System;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Entity.Audit;

public class UserEmailAddressLog : UserEmailAddress
{
    public required int UserEmailAddressLogId { get; set; }

    public required int SessionUserId { get; set; }

    public required DateTime DateTime { get; set; }
}
