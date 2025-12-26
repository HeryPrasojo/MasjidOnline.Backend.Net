using System;

namespace MasjidOnline.Business.Model.User.Internal;

public class GetOneResponse
{
    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public InternalUserStatus Status { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
