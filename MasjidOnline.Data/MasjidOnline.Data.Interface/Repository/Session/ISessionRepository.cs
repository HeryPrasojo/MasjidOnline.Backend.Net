using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Session;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.Session;

public interface ISessionRepository
{
    Task AddAndSaveAsync(Entity.Session.Session session);
    Task AddAsync(Entity.Session.Session setting);
    Task<SessionForStart?> GetForStartAsync(IEnumerable<byte> code);
    Task<int> GetMaxIdAsync();
    Task<ApplicationCulture> GetApplicationCultureAsync(int id);
    Task RemoveExpireAsync(DateTime dateTime);
    Task SetForAuthenticateAsync(int id, DateTime dateTime);
    void SetForLogin(int id, int userId, DateTime dateTime, ApplicationCulture applicationCulture);
    void SetUserId(int id, int userId, DateTime dateTime);
    Task SetUserIdAndSaveAsync(int id, int userId, DateTime dateTime);
}
