using System;
using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IUserEmailAddressLogRepository
{
    Task AddAddAsync(int id, DateTime dateTime, int logUserId, UserEmailAddress userEmailAddress);
    Task<int> GetMaxIdAsync();
}
