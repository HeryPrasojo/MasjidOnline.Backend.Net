
namespace MasjidOnline.Api.Model.Exception;

public class InputMismatchException : System.Exception
{
    public InputMismatchException()
    {
    }

    public InputMismatchException(string? message) : base(message)
    {
    }

    public InputMismatchException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }
}
