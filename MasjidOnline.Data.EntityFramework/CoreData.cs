using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Core;
using MasjidOnline.Data.EntityFramework.Core.Captcha;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Core.Captcha;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CoreData : ICoreData
{
    protected readonly CoreDataContext _dataContext;

    private ICaptchaAnswerRepository? _captchaAnswerRepository;
    private ICaptchaQuestionRepository? _captchaQuestionRepository;

    private ICoreSettingRepository? _coreSettingRepository;


    public CoreData(CoreDataContext dataContext)
    {
        _dataContext = dataContext;
    }


    public ICaptchaAnswerRepository CaptchaAnswer => _captchaAnswerRepository ??= new CaptchaAnswerRepository(_dataContext);

    public ICaptchaQuestionRepository CaptchaQuestion => _captchaQuestionRepository ??= new CaptchaQuestionRepository(_dataContext);


    public ICoreSettingRepository CoreSetting => _coreSettingRepository ??= new CoreSettingRepository(_dataContext);


    public async Task<int> SaveAsync()
    {
        return await _dataContext.SaveChangesAsync();
    }
}