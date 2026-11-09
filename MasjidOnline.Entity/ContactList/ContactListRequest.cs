using System;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Entity.ContactList;

public class ContactListRequest
{
    public required int Id { get; set; }
    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
    public required string NickName { get; set; }

    public required int ContactUserId { get; set; }
    public required ContactType ContactType { get; set; }
    public required string Contact { get; set; }

    public required RequestStatus Status { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}
