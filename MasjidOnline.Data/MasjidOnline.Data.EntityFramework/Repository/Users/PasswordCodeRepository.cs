using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.User;
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

    public async Task<PasswordCodeForPasswordSet?> GetForPasswordSetAsync(byte[] code)
    {
        return await _dbSet.Where(e => e.Code.SequenceEqual(code) && (e.UseDateTime == default))
            .Select(e => new PasswordCodeForPasswordSet
            {
                UserId = e.UserId,
                UseDateTime = e.UseDateTime,
            })
            .FirstOrDefaultAsync();
    }

    public void UpdateUseDateTime(byte[] code, DateTime useDateTime)
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
