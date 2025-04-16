using System;
using MasjidOnline.Business.Model.Responses;

namespace MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;

public class GetOneNewResponse : Response
{
    public required string EmailAddress { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
