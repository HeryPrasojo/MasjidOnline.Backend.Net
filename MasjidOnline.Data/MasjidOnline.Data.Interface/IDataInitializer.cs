using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDataInitializer
{
    Task InitializeAsync(IData data);
}
