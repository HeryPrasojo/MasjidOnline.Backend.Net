using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ISessionIdGenerator
{
    int SessionId { get; }

    Task InitializeAsync(IData data);
}
