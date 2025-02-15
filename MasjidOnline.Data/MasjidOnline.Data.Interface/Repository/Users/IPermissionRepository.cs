using System.Threading.Tasks;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Interface.Repository.Users;

public interface IPermissionRepository
{
    Task AddAsync(Permission permission);
    Task<Permission?> GetByUserIdAsync(int userId);
}
