using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Users;

public interface IUserEmailAddressRepository
{
    Task<int> GetMaxIdAsync();
}
