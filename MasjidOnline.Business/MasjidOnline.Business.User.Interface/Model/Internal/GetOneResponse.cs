using System;

namespace MasjidOnline.Business.User.Interface.Model.Internal;

public class GetOneResponse
{
    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public InternalStatus Status { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
