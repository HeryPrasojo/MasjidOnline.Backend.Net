using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Expired;

public class ForSetStatus
{
    public required int InfaqId { get; set; }

    public required ExpiredStatus Status { get; set; }
}
