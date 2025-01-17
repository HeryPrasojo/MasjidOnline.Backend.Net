using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Captcha;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Captcha;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class CaptchaData(CaptchaDataContext _captchaDataContext) : ICaptchaData
{
    private ICaptchaSettingRepository? _captchaSettingRepository;

    private ICaptchaAnswerRepository? _captchaAnswerRepository;
    private ICaptchaQuestionRepository? _captchaQuestionRepository;


    public ICaptchaSettingRepository CaptchaSetting => _captchaSettingRepository ??= new CaptchaSettingRepository(_captchaDataContext);


    public ICaptchaAnswerRepository CaptchaAnswer => _captchaAnswerRepository ??= new CaptchaAnswerRepository(_captchaDataContext);

    public ICaptchaQuestionRepository CaptchaQuestion => _captchaQuestionRepository ??= new CaptchaQuestionRepository(_captchaDataContext);


    public async Task SaveAsync()
    {
        await _captchaDataContext.SaveChangesAsync();
    }
}