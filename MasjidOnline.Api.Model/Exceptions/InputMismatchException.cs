
using System;

namespace MasjidOnline.Api.Model.Exceptions;

public class InputMismatchException : Exception
{
    public InputMismatchException()
    {
    }

    public InputMismatchException(string? message) : base(message)
    {
    }

    public InputMismatchException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
