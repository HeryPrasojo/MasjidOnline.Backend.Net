using System;

namespace MasjidOnline.Data.Interface.Model.Session;

public class SessionForAuthentication
{
    public required byte[] Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
