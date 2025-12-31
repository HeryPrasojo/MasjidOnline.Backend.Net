namespace MasjidOnline.Entity.Audit;

public class PersonLog : Log<PersonLogType>
{
    public required int PersonId { get; set; }

    public required int? UserId { get; set; }

    public required string? Name { get; set; }
}
