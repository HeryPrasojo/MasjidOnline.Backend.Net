using System.Collections.Generic;

namespace MasjidOnline.Data.Interface.Model.Infaq;

public class InfaqForGetMany
{
    public required long Total { get; set; }

    public required IEnumerable<InfaqForGetManyRecord> Records { get; set; }
}
