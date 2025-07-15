using MasjidOnline.Business.Model.Responses;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class GetOneResponse : Response
{
    public required GetOneResponseFlags Flags { get; set; }

    public required GetOneResponseInfaq Infaq { get; set; }
}

public class GetOneResponseInfaq
{
    public required string DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required string Amount { get; set; }


    public required string PaymentType { get; set; }

    public required string PaymentStatus { get; set; }
}

public class GetOneResponseFlags
{
    public bool CanExpire { get; set; }

    public bool CanSuccess { get; set; }

    public bool CanVoid { get; set; }
}