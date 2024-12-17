namespace MasjidOnline.Api.Model;

public abstract class ResponseBase
{
    public required ResponseResult Result { get; set; }
    public string? Message { get; set; }
}
