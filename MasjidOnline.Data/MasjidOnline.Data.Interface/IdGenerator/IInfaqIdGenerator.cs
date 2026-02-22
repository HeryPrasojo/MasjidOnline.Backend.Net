using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IInfaqIdGenerator
{
    int InfaqId { get; }

    Task InitializeAsync(IData data);
}
