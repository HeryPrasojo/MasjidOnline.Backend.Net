using System;

namespace MasjidOnline.Entity.Log;

public class Exception
{
    public required long Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string Message { get; set; }

    public string? StackTrace { get; set; }
}
