namespace MasjidOnline.Api.Model;

public abstract class ResponseBase
{
    public required ResponseResult ResultCode { get; set; }
    public string? ResultMessage { get; set; }
}
