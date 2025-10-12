namespace MasjidOnline.Business.Model.Responses;

public class ExceptionResponse : Response
{
    public ExceptionResponseException? Exception { get; set; }
}

public class ExceptionResponseException
{
    public required string Type { get; set; }

    public required string Message { get; set; }

    public required string? StackTrace { get; set; }

    public ExceptionResponseException? InnerException { get; set; }
}
