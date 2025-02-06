namespace MasjidOnline.Business.Interface.Model.Responses;

public class Response
{
    public required ResponseResult ResultCode { get; set; }
    public string? ResultMessage { get; set; }
}
