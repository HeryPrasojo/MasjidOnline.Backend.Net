using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Session;

namespace MasjidOnline.Data.Interface.Repository.Session;

public interface ISessionRepository
{
    Task AddAsync(Entity.Session.Session setting);
    Task<SessionForAuthentication?> GetForAuthenticationAsync(byte[] id);
    Task<int> GetMaxIdAsync();
}
