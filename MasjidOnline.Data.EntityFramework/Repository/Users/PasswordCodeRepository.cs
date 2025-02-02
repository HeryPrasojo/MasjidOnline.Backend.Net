using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Users;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Users;

public class PasswordCodeRepository(UsersDataContext _passwordCodeDataContext) : IPasswordCodeRepository
{
    private readonly DbSet<PasswordCode> _dbSet = _passwordCodeDataContext.Set<PasswordCode>();

    public async Task AddAsync(PasswordCode PasswordCode)
    {
        await _dbSet.AddAsync(PasswordCode);
    }

    public async Task<PasswordCode?> GetByCodeAsync(byte[] code)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Code == code);
    }
}
