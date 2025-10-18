using System;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Entity.Session;

public class Session
{
    public required int Id { get; set; }

    public required byte[] Code { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }


    // hack move to new SessionData
    public UserPreferenceApplicationCulture ApplicationCulture { get; set; }
}
