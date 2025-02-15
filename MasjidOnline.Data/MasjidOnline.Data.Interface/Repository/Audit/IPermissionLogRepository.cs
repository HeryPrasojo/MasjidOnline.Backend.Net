using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IPermissionLogRepository
{
    Task<int> GetMaxPermissionLogIdAsync();
}
