using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IAuthorizationInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
