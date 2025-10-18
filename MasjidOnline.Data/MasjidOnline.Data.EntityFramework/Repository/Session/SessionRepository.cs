using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Session;
using MasjidOnline.Data.Interface.ViewModel.Session;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Session;

public class SessionRepository(DbContext _dbContext) : ISessionRepository
{
    private readonly DbSet<Entity.Session.Session> _dbSet = _dbContext.Set<Entity.Session.Session>();

    public async Task AddAsync(Entity.Session.Session session)
    {
        await _dbSet.AddAsync(session);
    }

    public async Task AddAndSaveAsync(Entity.Session.Session session)
    {
        await _dbSet.AddAsync(session);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<UserPreferenceApplicationCulture> GetUserPreferenceApplicationCultureAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => e.ApplicationCulture)
            .FirstOrDefaultAsync();
    }

    public async Task<SessionForStart?> GetForStartAsync(byte[] code)
    {
        return await _dbSet.Where(e => e.Code.SequenceEqual(code))
            .Select(e => new SessionForStart
            {
                ApplicationCulture = e.ApplicationCulture,
                DateTime = e.DateTime,
                Id = e.Id,
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }

    public void SetForAuthenticate(int id, DateTime dateTime, UserPreferenceApplicationCulture? applicationCulture)
    {
        var session = new Entity.Session.Session
        {
            Code = default!,
            DateTime = dateTime,
            Id = id,
        };

        if (applicationCulture.HasValue) session.ApplicationCulture = applicationCulture.Value;


        var entityEntry = _dbSet.Attach(session);

        entityEntry.Property(e => e.DateTime).IsModified = true;

        if (applicationCulture.HasValue)
            entityEntry.Property(e => e.ApplicationCulture).IsModified = true;
    }
}
