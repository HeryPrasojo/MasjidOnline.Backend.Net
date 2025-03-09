using System.Collections.Generic;

namespace MasjidOnline.Data.Interface.ViewModel.Repository;

public class ManyResult<TRecords>
{
    public required long Total { get; set; }

    public required IEnumerable<TRecords> Records { get; set; }
}
