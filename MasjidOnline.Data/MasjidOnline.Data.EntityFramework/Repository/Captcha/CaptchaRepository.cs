using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.Captcha;
using MasjidOnline.Data.Interface.Repository.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Captcha;

public class CaptchaRepository(CaptchaDataContext _captchaDataContext) : ICaptchaRepository
{
    private readonly DbSet<Entity.Captcha.Captcha> _dbSet = _captchaDataContext.Set<Entity.Captcha.Captcha>();

    public async Task AddAndSaveAsync(Entity.Captcha.Captcha captcha)
    {
        await _dbSet.AddAsync(captcha);

        await _captchaDataContext.SaveChangesAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    public async Task<CaptchaForUpdate?> GetForUpdateAsync(int sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .OrderByDescending(e => e.Id)
            .Select(e => new CaptchaForUpdate
            {
                Id = e.Id,
                IsMatched = e.IsMatched,
                QuestionFloat = e.QuestionFloat,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<CaptchaForAdd?> GetForAddAsync(int sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .OrderByDescending(e => e.Id)
            .Select(e => new CaptchaForAdd
            {
                Id = e.Id,
                IsMatched = e.IsMatched,
                QuestionFloat = e.QuestionFloat,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CaptchaForInfaqAddByAnonym>> GetForInfaqAddByAnonymAsync(int sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .OrderByDescending(e => e.Id)
            .Select(e => new CaptchaForInfaqAddByAnonym
            {
                Id = e.Id,
                IsMatched = e.IsMatched,
            })
            .ToArrayAsync();
    }

    public void SetAnswer(int id, float answerFloat, bool isMatched, DateTime updateDateTime)
    {
        var user = new Entity.Captcha.Captcha
        {
            Id = id,
            AnswerFloat = answerFloat,
            IsMatched = isMatched,
            UpdateDateTime = updateDateTime,
        };

        var entityEntry = _dbSet.Attach(user);

        entityEntry.Property(e => e.AnswerFloat).IsModified = true;
        entityEntry.Property(e => e.IsMatched).IsModified = true;
        entityEntry.Property(e => e.UpdateDateTime).IsModified = true;
    }
}
