using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IUserInitializer
{
    Task InitializeDatabaseAsync(IUserData userData, int userId);
}
