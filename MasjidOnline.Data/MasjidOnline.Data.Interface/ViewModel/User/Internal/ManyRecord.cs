using System;

namespace MasjidOnline.Data.Interface.Model.User.Internal;

public class ManyRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string EmailAddress { get; set; }

    public required int UserId { get; set; }

    public required bool? IsApproved { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
