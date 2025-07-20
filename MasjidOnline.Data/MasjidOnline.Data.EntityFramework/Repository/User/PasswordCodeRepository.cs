using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class PasswordCodeRepository(UserDataContext _userDataContext) : IPasswordCodeRepository
{
    private readonly DbSet<PasswordCode> _dbSet = _userDataContext.Set<PasswordCode>();

    public async Task AddAsync(PasswordCode passwordCode)
    {
        await _dbSet.AddAsync(passwordCode);
    }

    public async Task<byte[]?> GetLatestCodeForSetPasswordAsync(int userId)
    {
        return await _dbSet.Where(e => (e.UserId == userId) && (e.UseDateTime == default))
            .OrderByDescending(e => e.DateTime)
            .Select(e => e.Code)
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
