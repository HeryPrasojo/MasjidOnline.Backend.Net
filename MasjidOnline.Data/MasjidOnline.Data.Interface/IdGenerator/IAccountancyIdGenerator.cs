using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IAccountancyIdGenerator
{
    int ExpenditureId { get; }

    Task InitializeAsync(IData data);
}
