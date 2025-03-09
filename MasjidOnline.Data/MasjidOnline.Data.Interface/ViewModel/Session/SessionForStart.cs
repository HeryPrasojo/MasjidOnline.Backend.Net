using System;

namespace MasjidOnline.Data.Interface.ViewModel.Session;

public class SessionForStart
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
