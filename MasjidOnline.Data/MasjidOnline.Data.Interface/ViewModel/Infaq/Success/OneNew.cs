using System;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Success;

public class OneNew
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
