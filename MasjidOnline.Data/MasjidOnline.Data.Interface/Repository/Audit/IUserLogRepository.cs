using System;
using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IUserLogRepository
{
    Task AddAddAsync(Entity.User.User user, int id, DateTime dateTime, int userId);
    Task<int> GetMaxIdAsync();
}
