using System;
using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IUserLogRepository
{
    Task AddAddAsync(int id, DateTime dateTime, int logUserId, Entity.User.User user);
    Task AddSetPasswordAsync(int id, DateTime dateTime, int logUserId, Entity.User.User user);
    Task<int> GetMaxIdAsync();
}
