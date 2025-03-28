using System.Collections.Generic;

namespace MasjidOnline.Business.Model.Responses;

public class GetManyResponse<TRecords> : Response
{
    public required IEnumerable<TRecords> Records { get; set; }

    public required long Total { get; set; }
}
