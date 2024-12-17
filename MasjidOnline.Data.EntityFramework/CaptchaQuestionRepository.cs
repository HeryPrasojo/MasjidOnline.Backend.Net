using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework;

public class CaptchaQuestionRepository(DataContext _dataContext) : ICaptchaQuestionRepository
{
    public DbSet<CaptchaQuestion> _captchaQuestion = _dataContext.Set<CaptchaQuestion>();

    public async Task AddAsync(CaptchaQuestion captchaQuestion)
    {
        await _captchaQuestion.AddAsync(captchaQuestion);
    }
}
