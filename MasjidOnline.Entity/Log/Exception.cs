using System;

// todo rename to MasjidOnline.Entity.EventLog
namespace MasjidOnline.Entity.Log;

public class Exception
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string Message { get; set; }

    public string? StackTrace { get; set; }
}
