using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IUserEmailAddressLogRepository
{
    Task<int> GetMaxUserEmailAddressLogIdAsync();
}
