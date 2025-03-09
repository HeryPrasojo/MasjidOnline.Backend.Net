using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Session;

namespace MasjidOnline.Data.Interface.Repository.Session;

public interface ISessionRepository
{
    Task AddAsync(Entity.Session.Session setting);
    Task<SessionForStart?> GetForStartAsync(byte[] digest);
    Task<int> GetMaxIdAsync();
}
