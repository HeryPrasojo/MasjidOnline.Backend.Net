using System;

namespace MasjidOnline.Library.Exceptions;

public class SessionMismatchException : Exception
{
    public SessionMismatchException(string? message) : base(message)
    {
    }

    public SessionMismatchException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
