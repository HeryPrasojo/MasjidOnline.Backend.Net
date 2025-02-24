using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.Session;
using MasjidOnline.Data.Interface.Repository.Sessions;
using MasjidOnline.Entity.Sessions;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Sessions;

public class SessionRepository(SessionsDataContext _sessionDataContext) : ISessionRepository
{
    private readonly DbSet<Session> _dbSet = _sessionDataContext.Set<Session>();

    public async Task AddAsync(Session session)
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
