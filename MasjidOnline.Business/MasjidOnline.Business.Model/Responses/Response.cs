namespace MasjidOnline.Business.Model.Responses;

public class Response
{
    public required ResponseResultCode ResultCode { get; set; }
    public string? ResultMessage { get; set; }
}

public class Response<T> : Response
{
    public T? Data { get; set; }
}
