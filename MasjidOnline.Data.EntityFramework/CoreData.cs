using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Core;
using MasjidOnline.Data.EntityFramework.Core.Captcha;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Core.Captcha;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CoreData(CoreDataContext _coreDataContext) : ICoreData
{
    private ICaptchaAnswerRepository? _captchaAnswerRepository;
    private ICaptchaQuestionRepository? _captchaQuestionRepository;

    private ICoreSettingRepository? _coreSettingRepository;

    public ICaptchaAnswerRepository CaptchaAnswer => _captchaAnswerRepository ??= new CaptchaAnswerRepository(_coreDataContext);

    public ICaptchaQuestionRepository CaptchaQuestion => _captchaQuestionRepository ??= new CaptchaQuestionRepository(_coreDataContext);


    public ICoreSettingRepository CoreSetting => _coreSettingRepository ??= new CoreSettingRepository(_coreDataContext);


    public async Task<int> SaveAsync()
    {
        return await _coreDataContext.SaveChangesAsync();
    }
}