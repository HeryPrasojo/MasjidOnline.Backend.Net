using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Session;
using MasjidOnline.Entity.Sessions;

namespace MasjidOnline.Data.Interface.Repository.Sessions;

public interface ISessionRepository
{
    Task AddAndSaveAsync(Session setting);
    Task<SessionForAuthentication?> GetForAuthenticationAsync(byte[] id);
    Task<int> GetMaxIdAsync();
}
