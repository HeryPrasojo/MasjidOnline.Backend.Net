using System;

namespace MasjidOnline.Library.Exceptions;

public class InputMismatchException : Exception
{
    public InputMismatchException(string? message) : base(message)
    {
    }

    public InputMismatchException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
