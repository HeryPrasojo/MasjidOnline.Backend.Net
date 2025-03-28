namespace MasjidOnline.Business.Model.Responses;

public class ExceptionResponse : Response
{
    public ExceptionResponseException? Exception { get; set; }
}
