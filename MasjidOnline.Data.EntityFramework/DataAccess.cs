using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Captcha;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Captcha;

namespace MasjidOnline.Data.EntityFramework;

public abstract class DataAccess(DataContext _dataContext) : IDataAccess
{
    private ICaptchaAnswerRepository? _captchaAnswerRepository;
    private ICaptchaQuestionRepository? _captchaQuestionRepository;

    public ICaptchaAnswerRepository CaptchaAnswerRepository
    {
        get
        {
            if (_captchaAnswerRepository == default)
            {
                _captchaAnswerRepository = new CaptchaAnswerRepository(_dataContext);
            }

            return _captchaAnswerRepository;
        }
    }

    public ICaptchaQuestionRepository CaptchaQuestionRepository
    {
        get
        {
            if (_captchaQuestionRepository == default)
            {
                _captchaQuestionRepository = new CaptchaQuestionRepository(_dataContext);
            }

            return _captchaQuestionRepository;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _dataContext.SaveChangesAsync();
    }
}