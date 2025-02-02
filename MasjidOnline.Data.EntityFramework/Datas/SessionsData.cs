using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Sessions;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Sessions;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class SessionsData(SessionsDataContext _sessionDataContext) : ISessionsData
{
    private ISessionSettingRepository? _sessionSettingRepository;

    private ISessionRepository? _sessionRepository;


    public ISessionSettingRepository SessionSetting => _sessionSettingRepository ??= new SessionSettingRepository(_sessionDataContext);


    public ISessionRepository Session => _sessionRepository ??= new SessionRepository(_sessionDataContext);


    public async Task SaveAsync()
    {
        await _sessionDataContext.SaveChangesAsync();
    }
}
