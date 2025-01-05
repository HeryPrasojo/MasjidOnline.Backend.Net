namespace MasjidOnline.Api.Model;

public class Response
{
    public required ResponseResult ResultCode { get; set; }
    public string? ResultMessage { get; set; }
}
