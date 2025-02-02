using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ISessionsIdGenerator
{

    Task InitializeAsync(ISessionsData sessionData);
}
