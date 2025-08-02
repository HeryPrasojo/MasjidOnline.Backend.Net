using MasjidOnline.Data.EntityFramework.Repository.Session;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Session;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class SessionDatabase(DbContext _dbContext) : Database(_dbContext), ISessionDatabase
{
    private ISessionSettingRepository? _sessionSettingRepository;

    private ISessionRepository? _sessionRepository;


    public ISessionSettingRepository SessionSetting => _sessionSettingRepository ??= new SessionSettingRepository(_dbContext);


    public ISessionRepository Session => _sessionRepository ??= new SessionRepository(_dbContext);
}
