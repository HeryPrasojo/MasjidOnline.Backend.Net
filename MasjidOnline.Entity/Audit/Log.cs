using System;

namespace MasjidOnline.Entity.Audit;

public abstract class Log<TLogType> where TLogType : Enum
{
    public required int Id { get; set; }

    public required DateTime LogDateTime { get; set; }

    public required int LogUserId { get; set; }

    public required TLogType LogType { get; set; }
}
