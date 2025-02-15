namespace MasjidOnline.Business.Interface.Model.Responses;

public class ExceptionResponse : Response
{
    public string? StackTrace { get; set; }

    public string? InnerMessage { get; set; }

    public string? InnerStackTrace { get; set; }
}
