using System;

namespace MasjidOnline.Business.Model.User.Internal;

public class GetManyNewResponseRecord
{
    public required DateTime DateTime { get; set; }

    public string EmailAddress { get; set; } = default!;

    public required int UserId { get; set; }

    public string? Description { get; set; }
}
