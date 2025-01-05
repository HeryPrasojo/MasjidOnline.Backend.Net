using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core.Captcha;
using MasjidOnline.Data.Model.Captcha;
using MasjidOnline.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Core.Captcha;

public class CaptchaQuestionRepository(CoreDataContext _dataContext) : ICaptchaQuestionRepository
{
    private readonly DbSet<CaptchaQuestion> _dbSet = _dataContext.Set<CaptchaQuestion>();

    public async Task AddAsync(CaptchaQuestion captchaQuestion)
    {
        await _dbSet.AddAsync(captchaQuestion);
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    public async Task<CaptchaQuestionForAnswer?> GetForAnswerAsync(string sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .OrderByDescending(e => e.Id)
            .Select(e => new CaptchaQuestionForAnswer
            {
                Id = e.Id,
                Degree = e.Degree,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<CaptchaQuestionForCreate?> GetForCreateAsync(string sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .OrderByDescending(e => e.Id)
            .Select(e => new CaptchaQuestionForCreate
            {
                Id = e.Id,
                Degree = e.Degree,
            })
            .FirstOrDefaultAsync();
    }
}
