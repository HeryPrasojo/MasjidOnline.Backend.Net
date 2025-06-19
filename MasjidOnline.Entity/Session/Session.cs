using System;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Entity.Session;

public class Session
{
    public required int Id { get; set; }

    public byte[] Digest { get; set; } = default!;

    public DateTime DateTime { get; set; }

    public int? PreviousId { get; set; }

    public int UserId { get; set; }

    public required UserPreferenceApplicationCulture ApplicationCulture { get; set; }
}
