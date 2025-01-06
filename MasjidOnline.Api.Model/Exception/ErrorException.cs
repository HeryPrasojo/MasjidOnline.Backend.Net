

namespace MasjidOnline.Api.Model.Exception;

public class ErrorException : System.Exception
{
    public ErrorException()
    {
    }

    public ErrorException(string? message) : base(message)
    {
    }

    public ErrorException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }
}
