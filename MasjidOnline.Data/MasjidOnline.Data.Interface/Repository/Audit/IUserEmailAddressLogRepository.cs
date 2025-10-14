using System;
using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IUserEmailAddressLogRepository
{
    Task AddAddAsync(UserEmailAddress userEmailAddress, int id, DateTime dateTime, int userId);
    Task<int> GetMaxIdAsync();
}
