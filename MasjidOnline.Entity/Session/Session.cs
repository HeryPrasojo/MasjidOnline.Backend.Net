using System;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Entity.Session;

public class Session
{
    public required int Id { get; set; }

    public byte[] Code { get; set; } = default!;

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }


    // hack low move to new SessionData
    public ApplicationCulture ApplicationCulture { get; set; }
}
