using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class UserEmailRepository(DbContext _dbContext) : IUserEmailRepository
{
    private readonly DbSet<UserEmail> _dbSet = _dbContext.Set<UserEmail>();

    public async Task AddAsync(UserEmail userEmail)
    {
        await _dbSet.AddAsync(userEmail);
    }

    public async Task<bool> AnyAsync(string emailAddress)
    {
        var pair = emailAddress.Split('@');

        var pair0 = pair[0].Split('+');

        var emailAddressLikePattern = (pair0.Length == 1) ? $"{pair[0]}+%@{pair[1]}" : $"{pair0[0]}+%@{pair[1]}";

        return await _dbSet.AnyAsync(e => (e.Address == emailAddress) || EF.Functions.Like(e.Address, emailAddressLikePattern));
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<int?> GetUserIdAsync(string emailAddress)
    {
        return await _dbSet.Where(e => e.Address == emailAddress)
            .Select(e => (int?)e.UserId)
            .FirstOrDefaultAsync();
    }
}
