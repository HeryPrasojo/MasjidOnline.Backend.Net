
using System;

namespace MasjidOnline.Library.Exceptions;

public class DataMismatchException : Exception
{
    public DataMismatchException(string? message) : base(message)
    {
    }

    public DataMismatchException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
