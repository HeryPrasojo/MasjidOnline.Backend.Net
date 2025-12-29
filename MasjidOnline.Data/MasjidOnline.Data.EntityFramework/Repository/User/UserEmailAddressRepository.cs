using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class UserEmailAddressRepository(DbContext _dbContext) : IUserEmailAddressRepository
{
    private readonly DbSet<UserEmailAddress> _dbSet = _dbContext.Set<UserEmailAddress>();

    public async Task AddAsync(UserEmailAddress userEmailAddress)
    {
        await _dbSet.AddAsync(userEmailAddress);
    }

    public async Task<bool> AnyAsync(string emailAddress)
    {
        var pair = emailAddress.Split('@');

        var pair0 = pair[0].Split('+');

        var emailAddressLikePattern = (pair0.Length == 1) ? $"{pair[0]}+%@{pair[1]}" : $"{pair0[0]}+%@{pair[1]}";

        return await _dbSet.AnyAsync(e => (e.EmailAddress == emailAddress) || EF.Functions.Like(e.EmailAddress, emailAddressLikePattern));
    }

    public async Task<int?> GetUserIdAsync(string emailAddress)
    {
        return await _dbSet.Where(e => e.EmailAddress == emailAddress)
            .Select(e => (int?)e.UserId)
            .FirstOrDefaultAsync();
    }
}
