
using System;

namespace MasjidOnline.Api.Model.Exceptions;

public class ErrorException : Exception
{
    public ErrorException()
    {
    }

    public ErrorException(string? message) : base(message)
    {
    }

    public ErrorException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
