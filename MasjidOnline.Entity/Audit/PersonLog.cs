namespace MasjidOnline.Entity.Audit;

public class PersonLog : Log<PersonLogType>
{
    public required int PersonId { get; set; }

    public int? UserId { get; set; }

    public required string? Name { get; set; }
}
