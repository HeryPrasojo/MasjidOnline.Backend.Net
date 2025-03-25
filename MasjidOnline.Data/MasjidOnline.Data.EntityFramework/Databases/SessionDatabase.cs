using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Session;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Session;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class SessionDatabase(SessionDataContext _sessionDataContext) : Data(_sessionDataContext), ISessionDatabase
{
    private ISessionSettingRepository? _sessionSettingRepository;

    private ISessionRepository? _sessionRepository;


    public ISessionSettingRepository SessionSetting => _sessionSettingRepository ??= new SessionSettingRepository(_sessionDataContext);


    public ISessionRepository Session => _sessionRepository ??= new SessionRepository(_sessionDataContext);
}
