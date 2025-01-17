using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Captcha;
using MasjidOnline.Data.Model.Captcha;
using MasjidOnline.Entity.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Captcha;

public class CaptchaQuestionRepository(CaptchaDataContext _captchaDataContext) : ICaptchaQuestionRepository
{
    private readonly DbSet<CaptchaQuestion> _dbSet = _captchaDataContext.Set<CaptchaQuestion>();

    public async Task AddAsync(CaptchaQuestion captchaQuestion)
    {
        await _dbSet.AddAsync(captchaQuestion);
    }

    public async Task AddAndSaveAsync(CaptchaQuestion captchaQuestion)
    {
        await AddAsync(captchaQuestion);

        await SaveAsync();
    }


    public async Task<IEnumerable<int>> GetIdsBySessionIdAsync(byte[] sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .Select(e => e.Id)
            .ToArrayAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    public async Task<CaptchaQuestionForAnswer?> GetForAnswerAsync(byte[] sessionId)
    {
        return await _dbSet.Where(e => e.SessionId.SequenceEqual(sessionId))
            .OrderByDescending(e => e.Id)
            .Select(e => new CaptchaQuestionForAnswer
            {
                Id = e.Id,
                Degree = e.Degree,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<CaptchaQuestionForCreate?> GetForCreateAsync(byte[] sessionId)
    {
        return await _dbSet.Where(e => e.SessionId.SequenceEqual(sessionId))
            .OrderByDescending(e => e.Id)
            .Select(e => new CaptchaQuestionForCreate
            {
                Id = e.Id,
                Degree = e.Degree,
            })
            .FirstOrDefaultAsync();
    }


    private async Task<int> SaveAsync()
    {
        return await _captchaDataContext.SaveChangesAsync();
    }
}
