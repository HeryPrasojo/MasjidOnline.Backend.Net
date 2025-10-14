using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class UserEmailAddressLogRepository(DbContext _dbContext) : IUserEmailAddressLogRepository
{
    private readonly DbSet<UserEmailAddressLog> _dbSet = _dbContext.Set<UserEmailAddressLog>();

    public async Task AddAddAsync(Entity.User.UserEmailAddress userEmailAddress, int id, DateTime dateTime, int userId)
    {
        var userEmailAddressLog = new UserEmailAddressLog
        {
            Id = id,
            LogDateTime = dateTime,
            LogType = UserEmailAddressLogType.Add,
            LogUserId = userId,

            UserId = userEmailAddress.UserId,
            EmailAddress = userEmailAddress.EmailAddress,
        };

        await _dbSet.AddAsync(userEmailAddressLog);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
