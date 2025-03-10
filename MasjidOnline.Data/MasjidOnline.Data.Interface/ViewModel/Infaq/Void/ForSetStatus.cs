using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Void;

public class ForSetStatus
{
    public required int InfaqId { get; set; }

    public required VoidStatus Status { get; set; }
}
