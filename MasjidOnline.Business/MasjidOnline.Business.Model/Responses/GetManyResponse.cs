using System.Collections.Generic;

namespace MasjidOnline.Business.Model.Responses;

public class GetManyResponse<TRecords> : Response
{
    public required IEnumerable<TRecords> Records { get; set; }

    public required long RecordCount { get; set; }

    public required long PageCount { get; set; }
}
