namespace MasjidOnline.Entity.Person
{
    public class Person
    {
        public required int Id { get; set; }

        public int? UserId { get; set; }

        public required string Name { get; set; }
    }
}
