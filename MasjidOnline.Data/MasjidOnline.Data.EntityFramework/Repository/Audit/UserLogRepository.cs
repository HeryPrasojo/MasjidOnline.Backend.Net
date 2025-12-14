using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class UserLogRepository(DbContext _dbContext) : IUserLogRepository
{
    private readonly DbSet<UserLog> _dbSet = _dbContext.Set<UserLog>();

    public async Task AddAddAsync(int id, DateTime dateTime, int logUserId, Entity.User.User user)
    {
        var userLog = new UserLog
        {
            Id = id,
            LogDateTime = dateTime,
            LogType = UserLogType.Add,
            LogUserId = logUserId,

            UserId = user.Id,
            Password = user.Password,
            Status = user.Status,
            Type = user.Type,
        };

        await _dbSet.AddAsync(userLog);
    }

    public async Task AddSetPasswordAsync(int id, DateTime dateTime, int logUserId, Entity.User.User user)
    {
        var userLog = new UserLog
        {
            Id = id,
            LogDateTime = dateTime,
            LogType = UserLogType.SetPassword,
            LogUserId = logUserId,

            Password = user.Password,
            UserId = user.Id,
        };

        await _dbSet.AddAsync(userLog);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
