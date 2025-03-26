using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IPersonIdGenerator
{
    Task InitializeAsync(IData data);
}
