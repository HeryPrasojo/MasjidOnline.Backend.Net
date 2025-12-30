using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class UserEmailLogRepository(DbContext _dbContext) : IUserEmailLogRepository
{
    private readonly DbSet<UserEmailLog> _dbSet = _dbContext.Set<UserEmailLog>();

    public async Task AddAddAsync(int id, DateTime dateTime, int logUserId, Entity.User.UserEmail userEmail)
    {
        var userEmailLog = new UserEmailLog
        {
            Id = id,
            LogDateTime = dateTime,
            LogType = UserEmailLogType.Add,
            LogUserId = logUserId,

            UserId = userEmail.UserId,
            Address = userEmail.Address,
        };

        await _dbSet.AddAsync(userEmailLog);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
