
using System;

namespace MasjidOnline.Api.Model.Exceptions;

public class DataMismatchException : Exception
{
    public DataMismatchException()
    {
    }

    public DataMismatchException(string? message) : base(message)
    {
    }

    public DataMismatchException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
