
namespace MasjidOnline.Api.Model.Exception;

public class DataMismatchException : System.Exception
{
    public DataMismatchException()
    {
    }

    public DataMismatchException(string? message) : base(message)
    {
    }

    public DataMismatchException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }
}
