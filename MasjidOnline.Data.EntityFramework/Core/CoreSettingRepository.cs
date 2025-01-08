using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Entity.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Captcha;

public class CaptchaSettingRepository(CaptchaDataContext _dataContext) : ICaptchaSettingRepository
{
    private readonly DbSet<CaptchaSetting> _dbSet = _dataContext.Set<CaptchaSetting>();

    public async Task AddAsync(CaptchaSetting captchaSetting)
    {
        await _dbSet.AddAsync(captchaSetting);
    }
}
