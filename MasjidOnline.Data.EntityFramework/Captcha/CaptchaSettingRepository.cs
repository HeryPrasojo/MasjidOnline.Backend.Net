using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Entity.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Captcha;

public class CaptchaSettingRepository(CaptchaDataContext _captchaDataContext) : ICaptchaSettingRepository
{
    private readonly DbSet<CaptchaSetting> _dbSet = _captchaDataContext.Set<CaptchaSetting>();

    public async Task AddAsync(CaptchaSetting captchaSetting)
    {
        await _dbSet.AddAsync(captchaSetting);
    }
}
