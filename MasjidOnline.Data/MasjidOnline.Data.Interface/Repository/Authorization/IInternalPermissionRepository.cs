using System.Threading.Tasks;
using MasjidOnline.Entity.Authorization;

namespace MasjidOnline.Data.Interface.Repository.Authorization;

public interface IInternalPermissionRepository
{
    Task AddAsync(InternalPermission permission);
    Task<InternalPermission?> GetByUserIdAsync(int userId);
}
