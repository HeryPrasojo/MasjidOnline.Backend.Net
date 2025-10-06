using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IUserIdGenerator
{
    int UserId { get; }
    int InternalId { get; }

    Task InitializeAsync(IData data);
}
