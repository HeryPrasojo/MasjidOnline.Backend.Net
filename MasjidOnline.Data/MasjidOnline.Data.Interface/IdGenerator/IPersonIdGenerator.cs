using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IPersonIdGenerator
{
    int PersonId { get; }

    Task InitializeAsync(IData data);
}
