namespace MasjidOnline.Business.Model.User.Internal;

public class GetManyResponseRecord
{
    public required int Id { get; set; }

    public required string DateTime { get; set; }

    public required string? PersonName { get; set; }

    public required string Status { get; set; }

    public required string? AddPersonName { get; set; }
}
