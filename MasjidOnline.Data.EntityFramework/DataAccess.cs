using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Captcha;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Captcha;

namespace MasjidOnline.Data.EntityFramework;

public abstract class DataAccess : IDataAccess
{
    protected readonly DataContext _dataContext;

    private ICaptchaAnswerRepository? _captchaAnswerRepository;
    private ICaptchaQuestionRepository? _captchaQuestionRepository;

    private ISettingRepository? _settingRepository;


    public DataAccess(DataContext dataContext)
    {
        _dataContext = dataContext;
    }


    public ICaptchaAnswerRepository CaptchaAnswerRepository => _captchaAnswerRepository ??= new CaptchaAnswerRepository(_dataContext);

    public ICaptchaQuestionRepository CaptchaQuestionRepository => _captchaQuestionRepository ??= new CaptchaQuestionRepository(_dataContext);


    public ISettingRepository SettingRepository => _settingRepository ??= new SettingRepository(_dataContext);


    public async Task<int> SaveAsync()
    {
        return await _dataContext.SaveChangesAsync();
    }
}