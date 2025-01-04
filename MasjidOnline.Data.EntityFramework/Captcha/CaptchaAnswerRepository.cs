using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Data.Model.Captcha;
using MasjidOnline.Entity;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Captcha;

public class CaptchaAnswerRepository(DataContext _dataContext) : ICaptchaAnswerRepository
{
    private readonly DbSet<CaptchaAnswer> _dbSet = _dataContext.Set<CaptchaAnswer>();

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
