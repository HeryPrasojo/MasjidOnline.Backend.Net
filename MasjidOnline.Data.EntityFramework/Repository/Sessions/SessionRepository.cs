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

    public async Task AddAndSaveAsync(Session session)
    {
        await _dbSet.AddAsync(session);

        await _sessionDataContext.SaveChangesAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<SessionForAuthentication?> GetForAuthenticationAsync(byte[] id)
    {
        return await _dbSet.Where(e => e.Digest.SequenceEqual(id))
            .Select(e => new SessionForAuthentication
            {
                DateTime = e.DateTime,
                Id = e.Digest,
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }
}
