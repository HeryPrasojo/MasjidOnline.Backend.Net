using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ISessionsIdGenerator
{
    byte[] SessionId { get; }

    Task InitializeAsync(ISessionsData sessionData);
}
