using System;

namespace MasjidOnline.Data.Interface.Model.Infaqs.Expired;

public class GetManyRecord
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public bool? IsApproved { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateUserId { get; set; }
}
