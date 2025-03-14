using System;

namespace MasjidOnline.Data.Interface.ViewModel.User.Internal;

public class OneNew
{
    public required string EmailAddress { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
