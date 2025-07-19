using MasjidOnline.Business.Model.Responses;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class GetOneResponse : Response
{
    public required string DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required string Amount { get; set; }


    public required string PaymentType { get; set; }

    public required string Status { get; set; }

    // todo wait remove
    public required GetOneResponseFlags Flags { get; set; }

    // todo wait remove
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
    public bool CanAddExpire { get; set; }

    public bool CanAddSuccess { get; set; }

    public bool CanAddVoid { get; set; }

    public bool CanApproveExpire { get; set; }

    public bool CanApproveSuccess { get; set; }

    public bool CanApproveVoid { get; set; }

    public bool CanCancelExpire { get; set; }

    public bool CanCancelSuccess { get; set; }

    public bool CanCancelVoid { get; set; }

    public bool CanVoid { get; set; }
}