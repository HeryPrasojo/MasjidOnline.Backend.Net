using System;

namespace MasjidOnline.Entity.ContactList;

public class ContactList
{
    public required int Id { get; set; }
    public required int UserId { get; set; }
    public DateTime DateTime { get; set; }

    public required int ContactUserId { get; set; }
    public required string NickName { get; set; }
}
