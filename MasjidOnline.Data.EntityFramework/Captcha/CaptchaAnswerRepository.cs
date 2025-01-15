using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Entity.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Captcha;

public class CaptchaAnswerRepository(CaptchaDataContext _captchaDataContext) : ICaptchaAnswerRepository
{
    private readonly DbSet<CaptchaAnswer> _dbSet = _captchaDataContext.Set<CaptchaAnswer>();

    public async Task AddAsync(CaptchaAnswer captchaAnswer)
    {
        await _dbSet.AddAsync(captchaAnswer);
    }

    public async Task<int> AddAndSaveAsync(CaptchaAnswer captchaAnswer)
    {
        await AddAsync(captchaAnswer);

        return await SaveAsync();
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    public async Task<bool> GetAnyIsMatchByCaptchaQuestionIdsAsync(IEnumerable<long> captchaQuestionIds)
    {
        return await _dbSet.AnyAsync(a => captchaQuestionIds.Any(i => i == a.CaptchaQuestionId) && a.IsMatch);
    }

    public async Task<bool?> GetIsMatchByCaptchaQuestionIdAsync(long captchaQuestionId)
    {
        return await _dbSet.Where(e => e.CaptchaQuestionId == captchaQuestionId)
            .Select(e => (bool?)e.IsMatch)
            .FirstOrDefaultAsync();
    }


    private async Task<int> SaveAsync()
    {
        return await _captchaDataContext.SaveChangesAsync();
    }
}
