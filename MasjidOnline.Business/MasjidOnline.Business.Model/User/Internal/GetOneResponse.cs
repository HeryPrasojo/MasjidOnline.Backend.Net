namespace MasjidOnline.Business.Model.User.Internal;

public class GetOneResponse
{
    public required string DateTime { get; set; }

    public required string? PersonName { get; set; }

    public string? Contact { get; set; }

    public string? ContactType { get; set; }

    public InternalUserStatus Status { get; set; }
    public required string StatusText { get; set; }

    public required string? Description { get; set; }

    public required string? AddPersonName { get; set; }

    public string? AddContact { get; set; }

    public string? AddContactType { get; set; }

    public required string? EditDateTime { get; set; }

    public required string? EditPersonName { get; set; }

    public string? EditContact { get; set; }

    public string? EditContactType { get; set; }
}
