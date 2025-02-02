using System;

namespace MasjidOnline.Entity.Sessions;

public class Session
{
    public required byte[] Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required byte[]? PreviousId { get; set; }

    public required int UserId { get; set; }
}
