using System;

namespace MasjidOnline.Business.User.Interface.Model.Internal;

public class GetOneNewResponse
{
    public required string EmailAddress { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
