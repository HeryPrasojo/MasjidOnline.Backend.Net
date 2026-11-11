using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class ContactListIdGenerator : IContactListIdGenerator
{
    private int _contactListId;
    private int _contactListRequestId;

    public async Task InitializeAsync(IData data)
    {
        _contactListId = await data.ContactList.ContactList.GetMaxIdAsync();
        _contactListRequestId = await data.ContactList.ContactListRequest.GetMaxIdAsync();
    }

    public int ContactListId => Interlocked.Increment(ref _contactListId);

    public int ContactListRequestId => Interlocked.Increment(ref _contactListRequestId);
}
