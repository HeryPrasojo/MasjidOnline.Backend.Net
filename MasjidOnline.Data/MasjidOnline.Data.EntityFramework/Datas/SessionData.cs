using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Session;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Session;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class SessionData(SessionDataContext _sessionDataContext) : Data(_sessionDataContext), ISessionData
{
    private ISessionSettingRepository? _sessionSettingRepository;

    private ISessionRepository? _sessionRepository;


    public ISessionSettingRepository SessionSetting => _sessionSettingRepository ??= new SessionSettingRepository(_sessionDataContext);


    public ISessionRepository Session => _sessionRepository ??= new SessionRepository(_sessionDataContext);
}
