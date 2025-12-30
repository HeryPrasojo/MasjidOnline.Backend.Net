using System;
using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IUserEmailLogRepository
{
    Task AddAddAsync(int id, DateTime dateTime, int logUserId, UserEmail userEmail);
    Task<int> GetMaxIdAsync();
}
