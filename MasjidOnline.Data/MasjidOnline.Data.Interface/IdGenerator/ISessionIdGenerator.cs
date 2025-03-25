using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ISessionIdGenerator
{
    byte[] SessionDigest { get; }
    int SessionId { get; }

    Task InitializeAsync(ISessionDatabase sessionDatabase);
}
