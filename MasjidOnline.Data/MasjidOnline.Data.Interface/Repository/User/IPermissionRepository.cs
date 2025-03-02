using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IPermissionRepository
{
    Task AddAsync(Permission permission);
    Task<Permission?> GetByUserIdAsync(int userId);
}
