using System;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;

public class SuccessAdd
{
    public required DateTime DateTime { get; set; }

    public required InfaqStatus Status { get; set; }
}
