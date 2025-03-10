using System;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Void;

public class ManyNewRecord
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
