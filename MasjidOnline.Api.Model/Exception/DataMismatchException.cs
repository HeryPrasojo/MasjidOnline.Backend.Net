﻿
namespace MasjidOnline.Api.Model.Exception;

// todo consider move to MasjidOnline.Api.Web
public class DataMismatchException : System.Exception
{
    public DataMismatchException()
    {
    }

    public DataMismatchException(string? message) : base(message)
    {
    }

    public DataMismatchException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }
}
