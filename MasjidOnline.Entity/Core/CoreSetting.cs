﻿using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Core;

public class CoreSetting
{
    [Key]
    public required string Key { get; set; }

    public required string Value { get; set; }
}
