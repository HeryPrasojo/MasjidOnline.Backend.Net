using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IDatabaseTemplateInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
