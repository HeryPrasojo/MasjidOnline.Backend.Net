using System.Threading.Tasks;
using MasjidOnline.Entity.Sessions;

namespace MasjidOnline.Data.Interface.Repository.Sessions;

public interface ISessionRepository
{
    Task AddAsync(Session setting);
}
