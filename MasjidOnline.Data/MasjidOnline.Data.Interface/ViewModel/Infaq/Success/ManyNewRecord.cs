using System;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Success;

public class ManyNewRecord
{
    public required int Id { get; set; }

    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
