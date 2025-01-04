using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Core;
using MasjidOnline.Data.EntityFramework.Core.Captcha;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Core.Captcha;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CoreData : ICoreData
{
    protected readonly DataContext _dataContext;

    private ICaptchaAnswerRepository? _captchaAnswerRepository;
    private ICaptchaQuestionRepository? _captchaQuestionRepository;

    private ISettingRepository? _settingRepository;


    public CoreData(DataContext dataContext)
    {
        _dataContext = dataContext;
    }


    public ICaptchaAnswerRepository CaptchaAnswer => _captchaAnswerRepository ??= new CaptchaAnswerRepository(_dataContext);

    public ICaptchaQuestionRepository CaptchaQuestion => _captchaQuestionRepository ??= new CaptchaQuestionRepository(_dataContext);


    public ISettingRepository Setting => _settingRepository ??= new SettingRepository(_dataContext);


    public async Task<int> SaveAsync()
    {
        return await _dataContext.SaveChangesAsync();
    }
}