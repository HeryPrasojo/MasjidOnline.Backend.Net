using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.User;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Interface.Repository.Users;

public interface IUserEmailAddressRepository
{
    Task AddAsync(UserEmailAddress userEmailAddress);
    Task<UserEmailAddressForLogin?> GetForLoginAsync(string emailAddress);
}
