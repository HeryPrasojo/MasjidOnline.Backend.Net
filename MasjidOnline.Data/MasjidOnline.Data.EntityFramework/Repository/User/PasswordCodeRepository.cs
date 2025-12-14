using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Data.Interface.ViewModel.User.PasswordCode;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class PasswordCodeRepository(DbContext _dbContext) : IPasswordCodeRepository
{
    private readonly DbSet<PasswordCode> _dbSet = _dbContext.Set<PasswordCode>();

    public async Task AddAsync(PasswordCode passwordCode)
    {
        await _dbSet.AddAsync(passwordCode);
    }

    public async Task<ForSetPassword?> GetForSetPasswordAsync(int userId)
    {
        return await _dbSet.Where(e => e.UserId == userId)
            .OrderByDescending(e => e.DateTime)
            .Select(e => new ForSetPassword
            {
                Code = e.Code,
                DateTime = e.DateTime,
                UseDateTime = e.UseDateTime,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<int?> GetUserIdForSetPasswordAsync(byte[] code)
    {
        return await _dbSet.Where(e => e.Code.SequenceEqual(code) && (e.UseDateTime == default))
            .Select(e => e.UserId)
            .FirstOrDefaultAsync();
    }

    public void SetUseDateTime(byte[] code, DateTime useDateTime)
    {
        var passwordCode = new PasswordCode
        {
            Code = code,
            UseDateTime = useDateTime,
        };

        _dbSet.Attach(passwordCode)
            .Property(e => e.UseDateTime)
            .IsModified = true;
    }
}
