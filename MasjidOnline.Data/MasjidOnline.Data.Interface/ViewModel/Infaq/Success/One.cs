using System;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Success;

public class One
{
    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public required SuccessStatus Status { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
