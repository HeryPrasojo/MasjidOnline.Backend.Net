﻿using System;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Entity.Audit;

public class UserEmailAddressLog : UserEmailAddress
{
    public required int UserEmailAddressLogId { get; set; }

    public required int SessionUserId { get; set; }

    public required DateTime DateTime { get; set; }
}