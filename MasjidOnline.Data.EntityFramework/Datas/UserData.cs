using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Users;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class UserData(UserDataContext _userDataContext, IAuditData _auditData) : IUserData
{
    private IUserSettingRepository? _userSettingRepository;

    private IUserRepository? _userRepository;
    private IUserEmailAddressRepository? _userEmailAddressRepository;


    public IUserSettingRepository UserSetting => _userSettingRepository ??= new UserSettingRepository(_userDataContext);


    public IUserRepository User => _userRepository ??= new UserRepository(_userDataContext);

    public IUserEmailAddressRepository UserEmailAddress => _userEmailAddressRepository ??= new UserEmailAddressRepository(_userDataContext);


    public async Task SaveAsync()
    {
        var entityEntries = _userDataContext.ChangeTracker.Entries();

        var entityStates = new[]
        {
            EntityState.Added,
            EntityState.Deleted,
            EntityState.Modified,
        };

        var objects = entityEntries.Where(e => Array.Exists(entityStates, s => s == e.State))
            .Select(e => e.Entity);

        await _auditData.AddAsync(objects);

        await _userDataContext.SaveChangesAsync();
    }
}
