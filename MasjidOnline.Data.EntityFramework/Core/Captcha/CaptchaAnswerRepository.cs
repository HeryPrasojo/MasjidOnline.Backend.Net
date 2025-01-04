using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core.Captcha;
using MasjidOnline.Data.Model.Captcha;
using MasjidOnline.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Core.Captcha;

public class CaptchaAnswerRepository(DataContext _dataContext) : ICaptchaAnswerRepository
{
    private readonly DbSet<CaptchaAnswer> _dbSet = _dataContext.Set<CaptchaAnswer>();

    public async Task AddAsync(CaptchaAnswer captchaAnswer)
    {
        await _dbSet.AddAsync(captchaAnswer);
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    public async Task<CaptchaAnswerForCreateQuestion?> GetForCreateQuestionAsync(long captchaQuestionId)
    {
        return await _dbSet.Where(e => e.CaptchaQuestionId == captchaQuestionId)
            .Select(e => new CaptchaAnswerForCreateQuestion
            {
                IsMatch = e.IsMatch,
            })
            .FirstOrDefaultAsync();
    }
}
