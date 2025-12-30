using System;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.ViewModel.User.Internal;

public class ManyRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public required InternalUserStatus Status { get; set; }

    public required string? Description { get; set; }

    public required int AddUserId { get; set; }
}
