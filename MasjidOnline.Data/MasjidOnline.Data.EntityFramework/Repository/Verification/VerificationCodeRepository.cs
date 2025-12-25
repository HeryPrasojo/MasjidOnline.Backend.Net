using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Verification;
using MasjidOnline.Data.Interface.ViewModel.Verification.VerificationCode;
using MasjidOnline.Entity.Verification;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Verification;

public class VerificationCodeRepository(DbContext _dbContext) : IVerificationCodeRepository
{
    private readonly DbSet<VerificationCode> _dbSet = _dbContext.Set<VerificationCode>();

    public async Task AddAsync(VerificationCode verificationCode)
    {
        await _dbSet.AddAsync(verificationCode);
    }

    public async Task AddAndSaveAsync(VerificationCode verificationCode)
    {
        await AddAsync(verificationCode);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<OneByCode?> GetByCodeAsync(byte[] code)
    {
        return await _dbSet.Where(e => e.Code.SequenceEqual(code))
            .Select(e => new OneByCode
            {
                Contact = e.Contact,
                ContactType = e.ContactType,
                DateTime = e.DateTime,
                Id = e.Id,
                UseDateTime = e.UseDateTime,
                UserId = e.UserId,
                Type = e.Type,
            })
            .FirstOrDefaultAsync();
    }

    public void SetUseDateTime(int id, DateTime useDateTime)
    {
        var passwordCode = new VerificationCode
        {
            Id = id,
            UseDateTime = useDateTime,
        };

        _dbSet.Attach(passwordCode)
            .Property(e => e.UseDateTime)
            .IsModified = true;
    }
}
