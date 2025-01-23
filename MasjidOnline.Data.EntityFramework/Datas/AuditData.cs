using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Audit;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class AuditData(AuditDataContext _auditDataContext, IAuditIdGenerator _auditIdGenerator/*, UserSession _userSession*/) : IAuditData
{
    private DbSet<UserLog>? _userLogDbSet;
    private DbSet<UserEmailAddressLog>? _userEmailAddressLogDbSet;

    private IAuditSettingRepository? _auditSettingRepository;

    private IUserLogRepository? _userLogRepository;
    private IUserEmailAddressLogRepository? _userEmailAddressLogRepository;


    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_auditDataContext);

    public IUserLogRepository UserLog => _userLogRepository ??= new UserLogRepository(_auditDataContext);
    public IUserEmailAddressLogRepository UserEmailAddressLog => _userEmailAddressLogRepository ??= new UserEmailAddressLogRepository(_auditDataContext);


    public void addAudit(ChangeTracker changeTracker)
    {
        var entityEntries = changeTracker.Entries();

        foreach (var entityEntry in entityEntries)
        {
            var entityStates = new[]
            {
                EntityState.Added,
                EntityState.Deleted,
                EntityState.Modified,
            };

            var exists = Array.Exists(entityStates, s => s == entityEntry.State);

            if (!exists) continue;


            var utcNow = DateTime.UtcNow;

            if (entityEntry.Entity is User user)
            {
                _userLogDbSet ??= _auditDataContext.Set<UserLog>();

                var userLog = new UserLog
                {
                    UserLogId = _auditIdGenerator.UserLogId,

                    Id = user.Id,

                    EmailAddressId = user.EmailAddressId,
                    Name = user.Name,
                    UserType = user.UserType,

                    SessionUserId = 0 /*_userSession.UserId*/,
                    DateTime = utcNow,
                };

                _userLogDbSet.Add(userLog);
            }
            else if (entityEntry.Entity is UserEmailAddress userEmailAddress)
            {
                _userEmailAddressLogDbSet ??= _auditDataContext.Set<UserEmailAddressLog>();

                var userEmailAddressLog = new UserEmailAddressLog
                {
                    UserEmailAddressLogId = _auditIdGenerator.UserEmailAddressLogId,

                    Id = userEmailAddress.Id,

                    Disabled = userEmailAddress.Disabled,
                    EmailAddress = userEmailAddress.EmailAddress,
                    UserId = userEmailAddress.UserId,

                    SessionUserId = 0 /*_userSession.UserId*/,
                    DateTime = utcNow,
                };

                _userEmailAddressLogDbSet.Add(userEmailAddressLog);
            }
        }
    }

    public async Task SaveAsync()
    {
        await _auditDataContext.SaveChangesAsync();
    }
}