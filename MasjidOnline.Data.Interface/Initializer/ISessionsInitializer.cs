using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.Initializer;

public interface ISessionsInitializer
{
    Task InitializeDatabaseAsync(ISessionsData sessionData);
}
