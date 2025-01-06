
namespace MasjidOnline.Api.Model.Exception;

public class InputInvalidException : System.Exception
{
    public InputInvalidException()
    {
    }

    public InputInvalidException(string? message) : base(message)
    {
    }

    public InputInvalidException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }
}
