using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Captcha;
using MasjidOnline.Entity.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Captcha;

public class CaptchaAnswerRepository(CaptchaDataContext _captchaDataContext) : ICaptchaAnswerRepository
{
    private readonly DbSet<CaptchaAnswer> _dbSet = _captchaDataContext.Set<CaptchaAnswer>();

    public async Task AddAndSaveAsync(CaptchaAnswer captchaAnswer)
    {
        await _dbSet.AddAsync(captchaAnswer);

        await _captchaDataContext.SaveChangesAsync();
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
