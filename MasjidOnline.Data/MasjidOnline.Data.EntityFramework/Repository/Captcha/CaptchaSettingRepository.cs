using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Captcha;
using MasjidOnline.Entity.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Captcha;

public class CaptchaSettingRepository(DbContext _dbContext) : ICaptchaSettingRepository
{
    private readonly DbSet<CaptchaSetting> _dbSet = _dbContext.Set<CaptchaSetting>();

    public async Task AddAndSaveAsync(CaptchaSetting captchaSetting)
    {
        await _dbSet.AddAsync(captchaSetting);

        await _dbContext.SaveChangesAsync();
    }
}
