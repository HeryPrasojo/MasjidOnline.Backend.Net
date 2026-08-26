using System;

namespace MasjidOnline.Data.Interface.ViewModel.Approval;

public class View
{
    public required DateTime DateTime { get; set; }
    public required int UserId { get; set; }
    public string? Description { get; set; }
}
