using System;

namespace MasjidOnline.Entity.User;

public class Register
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required RegisterWith With { get; set; }

    public required string WithId { get; set; }

    public required string Code { get; set; }
}
