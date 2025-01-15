
using System;

namespace MasjidOnline.Api.Model.Exceptions;

public class InputInvalidException : Exception
{
    public InputInvalidException()
    {
    }

    public InputInvalidException(string? message) : base(message)
    {
    }

    public InputInvalidException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
