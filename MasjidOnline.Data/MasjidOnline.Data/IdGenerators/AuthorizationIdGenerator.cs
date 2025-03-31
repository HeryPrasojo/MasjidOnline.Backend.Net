using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class AuthorizationIdGenerator : IAuthorizationIdGenerator
{
    //private int _internalPermissionId;

    public async Task InitializeAsync(IData data)
    {
        //_internalPermissionId = await data.Authorization.InternalPermission.GetMaxIdAsync();
    }

    //public int InternalPermissionId => Interlocked.Increment(ref _internalPermissionId);
}
