using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Captcha;
using MasjidOnline.Data.Interface.Captcha;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CaptchaData(CaptchaDataContext _captchaDataContext) : ICaptchaData
{
    private ICaptchaAnswerRepository? _captchaAnswerRepository;
    private ICaptchaQuestionRepository? _captchaQuestionRepository;

    private ICaptchaSettingRepository? _captchaSettingRepository;

    public ICaptchaAnswerRepository CaptchaAnswer => _captchaAnswerRepository ??= new CaptchaAnswerRepository(_captchaDataContext);

    public ICaptchaQuestionRepository CaptchaQuestion => _captchaQuestionRepository ??= new CaptchaQuestionRepository(_captchaDataContext);


    public ICaptchaSettingRepository CaptchaSetting => _captchaSettingRepository ??= new CaptchaSettingRepository(_captchaDataContext);


    public async Task<int> SaveAsync()
    {
        return await _captchaDataContext.SaveChangesAsync();
    }
}