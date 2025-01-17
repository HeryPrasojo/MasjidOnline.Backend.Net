using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Users;

public interface IUserRepository
{
    Task<int> GetMaxIdAsync();
}
