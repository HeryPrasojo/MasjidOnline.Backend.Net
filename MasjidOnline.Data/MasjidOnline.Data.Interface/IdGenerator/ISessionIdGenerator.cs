using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ISessionIdGenerator
{
    byte[] SessionDigest { get; }
    int SessionId { get; }

    Task InitializeAsync(IData data);
}
