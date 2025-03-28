using System;

namespace MasjidOnline.Entity.Event;

public class Exception
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string Type { get; set; }

    public required string Message { get; set; }

    public string? StackTrace { get; set; }

    public int? InnerExceptionId { get; set; }
}
