namespace MasjidOnline.Business.Interface.Model;

public abstract class Response
{
    public required ResponseResult ResultCode { get; set; }
    public string? ResultMessage { get; set; }
}
