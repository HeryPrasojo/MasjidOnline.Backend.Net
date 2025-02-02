namespace MasjidOnline.Business.Interface.Model;

public class Session
{
    public required byte[] SessionId { get; set; }

    public required int UserId { get; set; }
}
