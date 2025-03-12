using System;

namespace MasjidOnline.Data.Interface.ViewModel.User.Internal;

public class ManyNewRecord
{
    public required DateTime DateTime { get; set; }

    public string EmailAddress { get; set; } = default!;

    public required int UserId { get; set; }

    public string? Description { get; set; }
}
