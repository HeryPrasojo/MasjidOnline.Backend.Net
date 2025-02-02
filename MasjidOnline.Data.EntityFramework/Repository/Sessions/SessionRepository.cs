using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
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

    public async Task<Session?> GetFirstByIdAsync(byte[] id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }
}
