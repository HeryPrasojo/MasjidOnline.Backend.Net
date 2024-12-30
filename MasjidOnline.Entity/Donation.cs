using System;

namespace MasjidOnline.Entity;

public class Donation
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public int? UserId { get; set; }

    public string? AnonymousName { get; set; }
}
