using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Session;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.Session;

public interface ISessionRepository
{
    Task AddAsync(Entity.Session.Session setting);
    Task<SessionForStart?> GetForStartAsync(byte[] digest);
    Task<int> GetMaxIdAsync();
    void SetApplicationCulture(int id, UserPreferenceApplicationCulture applicationCulture);
}
