﻿using System;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Model.Infaq.Expired;

public class ManyRecord
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public required ExpiredStatus Status { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
