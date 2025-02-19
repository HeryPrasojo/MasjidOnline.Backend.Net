namespace MasjidOnline.Business.Interface.Model.Responses;

public class Response
{
    public required ResponseResultCode ResultCode { get; set; }
    public string? ResultMessage { get; set; }
}
