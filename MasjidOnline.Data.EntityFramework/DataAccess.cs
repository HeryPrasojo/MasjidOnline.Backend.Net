using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data.EntityFramework;

public abstract class DataAccess(DataContext _dataContext) : IDataAccess
{
    private ICaptchaQuestionRepository? _captchaQuestionRepository;

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