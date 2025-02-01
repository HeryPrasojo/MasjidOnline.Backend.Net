namespace MasjidOnline.Business.Interface.Model;

public class Session
{
    public required byte[] RequestSessionId { get; set; }

    public required byte[] ResponseSessionId { get; set; }

    public required int UserId { get; set; }
}
