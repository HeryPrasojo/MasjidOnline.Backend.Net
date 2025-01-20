using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IUserLogRepository
{
    Task<int> GetMaxIdAsync();
}
