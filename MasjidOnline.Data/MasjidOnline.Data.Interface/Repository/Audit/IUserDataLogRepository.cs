using System;
using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IUserDataLogRepository
{
    Task AddAddAsync(int id, DateTime dateTime, int logUserId, UserData userData);
    Task<int> GetMaxIdAsync();
}
