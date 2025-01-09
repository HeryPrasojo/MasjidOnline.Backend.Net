using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Data.Model.Captcha;
using MasjidOnline.Entity.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Captcha;

public class CaptchaQuestionRepository(CaptchaDataContext _captchaDataContext) : ICaptchaQuestionRepository
{
    private readonly DbSet<CaptchaQuestion> _dbSet = _captchaDataContext.Set<CaptchaQuestion>();

    public async Task AddAsync(CaptchaQuestion captchaQuestion)
    {
        await _dbSet.AddAsync(captchaQuestion);
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
}
