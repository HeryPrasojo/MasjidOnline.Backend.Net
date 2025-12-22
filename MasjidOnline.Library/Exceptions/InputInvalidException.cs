using System;

namespace MasjidOnline.Library.Exceptions;

public class InputInvalidException : Exception
{
    // todo add field name
    public InputInvalidException(string? message) : base(message)
    {
    }

    public InputInvalidException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
