﻿using System;

namespace MasjidOnline.Entity.Users;

public class PasswordCode
{
    public required byte[] Code { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }


    // optimization

    public DateTime? UseDateTime { get; set; }
}
