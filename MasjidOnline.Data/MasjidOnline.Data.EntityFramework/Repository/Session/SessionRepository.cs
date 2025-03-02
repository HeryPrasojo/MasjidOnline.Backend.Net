using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.Session;
using MasjidOnline.Data.Interface.Repository.Session;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Session;

public class SessionRepository(SessionDataContext _sessionDataContext) : ISessionRepository
{
    private readonly DbSet<Entity.Session.Session> _dbSet = _sessionDataContext.Set<Entity.Session.Session>();

    public async Task AddAsync(Entity.Session.Session session)
    {
        await _dbSet.AddAsync(session);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<SessionForAuthentication?> GetForAuthenticationAsync(byte[] digest)
    {
        return await _dbSet.Where(e => e.Digest.SequenceEqual(digest))
            .Select(e => new SessionForAuthentication
            {
                DateTime = e.DateTime,
                Id = e.Id,
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }
}
