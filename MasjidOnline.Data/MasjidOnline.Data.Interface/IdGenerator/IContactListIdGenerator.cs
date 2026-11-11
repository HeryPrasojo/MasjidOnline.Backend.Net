using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IContactListIdGenerator
{
    int ContactListId { get; }
    int ContactListRequestId { get; }

    Task InitializeAsync(IData data);
}
