﻿namespace MasjidOnline.Business.Infaq.Interface.Model.Expired;

public class GetManyNewResponseRecord
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
