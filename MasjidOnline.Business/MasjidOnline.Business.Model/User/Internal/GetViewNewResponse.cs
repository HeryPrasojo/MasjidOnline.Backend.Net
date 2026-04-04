using System;

namespace MasjidOnline.Business.Model.User.Internal;

public class GetViewNewResponse
{
    public required string EmailAddress { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
