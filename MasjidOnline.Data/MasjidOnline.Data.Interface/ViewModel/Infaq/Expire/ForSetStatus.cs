using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Expire;

public class ForSetStatus
{
    public required int InfaqId { get; set; }

    public required ExpireStatus Status { get; set; }
}
