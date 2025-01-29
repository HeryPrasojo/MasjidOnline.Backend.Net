using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Audit;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Data.Mapper;
using MasjidOnline.Entity.Audit;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class AuditData(AuditDataContext _auditDataContext, IAuditIdGenerator _auditIdGenerator, UserSession _userSession) : IAuditData
{
    private DbSet<UserLog>? _userLogDbSet;
    private DbSet<UserEmailAddressLog>? _userEmailAddressLogDbSet;

    private IAuditSettingRepository? _auditSettingRepository;
    private IUserEmailAddressLogRepository? _userEmailAddressLogRepository;
    private IUserLogRepository? _userLogRepository;

    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_auditDataContext);
    public IUserEmailAddressLogRepository UserEmailAddressLog => _userEmailAddressLogRepository ??= new UserEmailAddressLogRepository(_auditDataContext);
    public IUserLogRepository UserLog => _userLogRepository ??= new UserLogRepository(_auditDataContext);

    internal async Task AddAsync(IEnumerable<EntityEntry> entityEntries)
    {
        var entityStates = new[]
       {
            EntityState.Added,
            EntityState.Deleted,
            EntityState.Modified,
        };

        var utcNow = DateTime.UtcNow;

        foreach (var entityEntry in entityEntries)
        {
            var exists = Array.Exists(entityStates, s => s == entityEntry.State);

            if (!exists) continue;


            if (entityEntry.Entity is User user)
            {
                _userLogDbSet ??= _auditDataContext.Set<UserLog>();

                var userLog = user.MapUserLog(_auditIdGenerator.UserLogId, _userSession.UserId, utcNow);

                await _userLogDbSet.AddAsync(userLog);
            }
            else if (entityEntry.Entity is UserEmailAddress userEmailAddress)
            {
                _userEmailAddressLogDbSet ??= _auditDataContext.Set<UserEmailAddressLog>();

                var userEmailAddressLog = userEmailAddress.MapUserEmailAddressLog(_auditIdGenerator.UserEmailAddressLogId, _userSession.UserId, utcNow);

                await _userEmailAddressLogDbSet.AddAsync(userEmailAddressLog);
            }
        }
    }

    public async Task SaveAsync()
    {
        await _auditDataContext.SaveChangesAsync();
    }
}