using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Core;
using MasjidOnline.Data.EntityFramework.Core.Captcha;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Core.Captcha;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CaptchaData(CaptchaDataContext _captchaDataContext) : ICaptchaData
{
    private ICaptchaAnswerRepository? _captchaAnswerRepository;
    private ICaptchaQuestionRepository? _captchaQuestionRepository;

    private ICoreSettingRepository? _coreSettingRepository;

    public ICaptchaAnswerRepository CaptchaAnswer => _captchaAnswerRepository ??= new CaptchaAnswerRepository(_captchaDataContext);

    public ICaptchaQuestionRepository CaptchaQuestion => _captchaQuestionRepository ??= new CaptchaQuestionRepository(_captchaDataContext);


    public ICoreSettingRepository CoreSetting => _coreSettingRepository ??= new CoreSettingRepository(_captchaDataContext);


    public async Task<int> SaveAsync()
    {
        return await _captchaDataContext.SaveChangesAsync();
    }
}