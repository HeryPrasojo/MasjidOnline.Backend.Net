namespace MasjidOnline.Business.Model.Responses;

public class ExceptionResponseException
{
    public required string Message { get; set; }

    public string? StackTrace { get; set; }

    public ExceptionResponseException? InnerException { get; set; }
}
