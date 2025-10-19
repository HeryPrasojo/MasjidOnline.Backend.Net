using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Session;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.Session;

public interface ISessionRepository
{
    Task AddAndSaveAsync(Entity.Session.Session session);
    Task AddAsync(Entity.Session.Session setting);
    Task<SessionForStart?> GetForStartAsync(byte[] digest);
    Task<int> GetMaxIdAsync();
    Task<UserPreferenceApplicationCulture> GetUserPreferenceApplicationCultureAsync(int id);
    void SetForAuthenticate(int id, DateTime dateTime, UserPreferenceApplicationCulture? applicationCulture);
    void SetUserId(int id, int userId, DateTime dateTime);
    Task SetUserIdAndSaveAsync(int id, int userId, DateTime dateTime);
}
