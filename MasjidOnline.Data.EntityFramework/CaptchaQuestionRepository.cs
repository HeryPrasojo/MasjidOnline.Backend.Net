using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework;

public class CaptchaQuestionRepository(DataContext _dataContext) : ICaptchaQuestionRepository
{
    public DbSet<CaptchaQuestion> _dbSet = _dataContext.Set<CaptchaQuestion>();

    public async Task AddAsync(CaptchaQuestion captchaQuestion)
    {
        captchaQuestion.Id = (await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0) + 1;

        await _dbSet.AddAsync(captchaQuestion);
    }
}
