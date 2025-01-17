
using System;

namespace MasjidOnline.Library.Exceptions;

public class InputInvalidException : Exception
{
    public InputInvalidException(string? message) : base(message)
    {
    }

    public InputInvalidException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
