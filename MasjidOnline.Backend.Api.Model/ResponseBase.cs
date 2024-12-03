using System;

namespace MasjidOnline.Backend.Api.Model;

public abstract class ResponseBase
{
    public Enum Error { get; set; }
}
