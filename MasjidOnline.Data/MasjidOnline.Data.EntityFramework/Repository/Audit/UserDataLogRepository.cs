using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class UserDataLogRepository(DbContext _dbContext) : IUserDataLogRepository
{
    private readonly DbSet<UserDataLog> _dbSet = _dbContext.Set<UserDataLog>();

    public async Task AddAddAsync(int id, DateTime dateTime, int logUserId, Entity.User.UserData userData)
    {
        var userLog = new UserDataLog
        {
            Id = id,
            LogDateTime = dateTime,
            LogType = UserDataLogType.Add,
            LogUserId = logUserId,

            ApplicationCulture = userData.ApplicationCulture,
            IsAcceptAgreement = userData.IsAcceptAgreement,
            UserId = userData.UserId,
        };

        await _dbSet.AddAsync(userLog);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => e.Id);
    }
}
