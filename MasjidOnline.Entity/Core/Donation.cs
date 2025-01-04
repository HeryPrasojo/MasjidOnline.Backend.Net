using System;

namespace MasjidOnline.Entity.Core;

public class Donation
{
    public required long Id { get; set; }

    public required DateTime DateTime { get; set; }

    public long? UserId { get; set; }

    public string? AnonymousName { get; set; }
}
