namespace MasjidOnline.Business.Interface.Model;

public class Session
{
    public required byte[] Id { get; set; }

    public byte[]? NewId { get; set; }

    public required int UserId { get; set; }
}
