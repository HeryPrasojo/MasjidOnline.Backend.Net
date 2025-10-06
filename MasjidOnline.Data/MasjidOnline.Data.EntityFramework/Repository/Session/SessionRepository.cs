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

    public void SetApplicationCulture(int id, UserPreferenceApplicationCulture applicationCulture)
    {
        var user = new Entity.Session.Session
        {
            Code = default!,
            Id = id,
            ApplicationCulture = applicationCulture,
        };

        var entityEntry = _dbSet.Attach(user);

        entityEntry.Property(e => e.ApplicationCulture).IsModified = true;
    }

    public async Task SetDateTimeAsync(int id, DateTime dateTime)
    {
        var session = new Entity.Session.Session
        {
            ApplicationCulture = default!,
            Id = id,
            Code = default!,
            DateTime = dateTime,
        };

        _dbSet.Attach(session)
            .Property(e => e.DateTime)
            .IsModified = true;


        await _dbContext.SaveChangesAsync();
    }
}
