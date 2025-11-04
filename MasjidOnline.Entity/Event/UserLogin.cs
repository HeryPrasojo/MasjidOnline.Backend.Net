using System;

namespace MasjidOnline.Entity.Event;

public class UserLogin
{
    public required int Id { get; set; }

    public required int UserId { get; set; }

    public required int SessionId { get; set; }

    public required string UserIdString { get; set; }

    public required DateTime DateTime { get; set; }

    public required UserLoginClient Client { get; set; }

    public required string? UserAgent { get; set; }

    public required double? LocationLatitude { get; set; }
    public required double? LocationLongitude { get; set; }
    public required double? LocationPrecision { get; set; }
    public required double? LocationAltitude { get; set; }
    public required double? LocationAltitudePrecision { get; set; }

    public required string? IpAddress { get; set; }
}
