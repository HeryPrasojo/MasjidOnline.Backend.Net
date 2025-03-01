using System;

namespace MasjidOnline.Data.Interface.Model.Infaqs.Expired;

public class GetManyUnprovedRecord
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
