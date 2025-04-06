using System;

namespace MasjidOnline.Library.Exceptions;

public class SessionExpireException : Exception
{
    public SessionExpireException(string? message) : base(message)
    {
    }

    public SessionExpireException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
