using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IInfaqInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
