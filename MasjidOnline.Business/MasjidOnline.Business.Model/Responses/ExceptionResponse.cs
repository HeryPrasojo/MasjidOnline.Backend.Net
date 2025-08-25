namespace MasjidOnline.Business.Model.Responses;

public class ExceptionResponse
{
    public required string Type { get; set; }

    public required string Message { get; set; }

    public string? StackTrace { get; set; }

    public ExceptionResponse? InnerException { get; set; }
}
