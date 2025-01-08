using System;

namespace MasjidOnline.Entity.Log;

public class ErrorException
{
    public required long Id { get; set; }

    public required string Message { get; set; }

    public string? StackTrace { get; set; }

    public required DateTime CreateDateTime { get; set; }
}
