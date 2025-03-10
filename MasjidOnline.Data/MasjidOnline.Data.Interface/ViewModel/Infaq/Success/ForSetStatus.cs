using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Success;

public class ForSetStatus
{
    public required int InfaqId { get; set; }

    public required SuccessStatus Status { get; set; }
}
