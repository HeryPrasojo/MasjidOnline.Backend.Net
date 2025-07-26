using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Captcha;
using MasjidOnline.Entity.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Captcha;

// todo low change *DataContext to DbContext
public class CaptchaSettingRepository(CaptchaDataContext _captchaDataContext) : ICaptchaSettingRepository
{
    private readonly DbSet<CaptchaSetting> _dbSet = _captchaDataContext.Set<CaptchaSetting>();

    public async Task AddAsync(CaptchaSetting captchaSetting)
    {
        await _dbSet.AddAsync(captchaSetting);
    }
}
