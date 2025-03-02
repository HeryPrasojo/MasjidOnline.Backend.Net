using System;

namespace MasjidOnline.Entity.Session;

public class Session
{
    public required int Id { get; set; }

    public required byte[] Digest { get; set; }

    public required DateTime DateTime { get; set; }

    public required byte[]? PreviousId { get; set; }

    public required int UserId { get; set; }
}
