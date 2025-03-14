using System;
using MasjidOnline.Business.Interface.Model.Responses;

namespace MasjidOnline.Business.User.Interface.Model.Internal;

public class GetOneNewResponse : Response
{
    public required string EmailAddress { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
