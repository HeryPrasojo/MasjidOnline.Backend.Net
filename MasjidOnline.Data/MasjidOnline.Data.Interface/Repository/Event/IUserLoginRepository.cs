using System.Threading.Tasks;
using MasjidOnline.Entity.Event;

namespace MasjidOnline.Data.Interface.Repository.Event;

public interface IUserLoginRepository
{
    Task AddAsync(UserLogin userLogin);
    Task<int> GetMaxIdAsync();
}
