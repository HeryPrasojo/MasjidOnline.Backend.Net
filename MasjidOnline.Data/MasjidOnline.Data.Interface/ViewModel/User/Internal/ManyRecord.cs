using System;
using MasjidOnline.Entity.User;

// todo rename sync match
namespace MasjidOnline.Data.Interface.Model.User.Internal;

public class ManyRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string EmailAddress { get; set; }

    public required int UserId { get; set; }

    public InternalStatus Status { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
