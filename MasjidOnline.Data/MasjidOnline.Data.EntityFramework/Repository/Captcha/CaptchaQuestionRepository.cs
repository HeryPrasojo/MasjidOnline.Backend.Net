﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.Captcha;
using MasjidOnline.Data.Interface.Repository.Captcha;
using MasjidOnline.Entity.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Captcha;

public class CaptchaQuestionRepository(CaptchaDataContext _captchaDataContext) : ICaptchaQuestionRepository
{
    private readonly DbSet<CaptchaQuestion> _dbSet = _captchaDataContext.Set<CaptchaQuestion>();

    public async Task AddAsync(CaptchaQuestion captchaQuestion)
    {
        await _dbSet.AddAsync(captchaQuestion);
    }

    public async Task AddAndSaveAsync(CaptchaQuestion captchaQuestion)
    {
        await AddAsync(captchaQuestion);

        await SaveAsync();
    }


    public async Task<IEnumerable<int>> GetIdsBySessionIdAsync(int sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .Select(e => e.Id)
            .ToArrayAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    public async Task<CaptchaQuestionForAnswer?> GetForAnswerAsync(int sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .OrderByDescending(e => e.Id)
            .Select(e => new CaptchaQuestionForAnswer
            {
                Id = e.Id,
                Degree = e.Degree,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<CaptchaQuestionForCreate?> GetForCreateAsync(int sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .OrderByDescending(e => e.Id)
            .Select(e => new CaptchaQuestionForCreate
            {
                Degree = e.Degree,
                Id = e.Id,
                IsMatched = e.IsMatched,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CaptchaQuestionForAnonymInfaq>> GetForAnonymInfaqAsync(int sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .OrderByDescending(e => e.Id)
            .Select(e => new CaptchaQuestionForAnonymInfaq
            {
                Id = e.Id,
                IsMatched = e.IsMatched,
            })
            .ToArrayAsync();
    }


    private async Task<int> SaveAsync()
    {
        return await _captchaDataContext.SaveChangesAsync();
    }
}
