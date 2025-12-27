using MasjidOnline.Data.EntityFramework.Repository.User;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class UserDatabase(DbContext _dbContext) : Database(_dbContext), IUserDatabase
{
    private IInternalUserRepository? _internalUserRepository;
    private IUserRepository? _userRepository;
    private IUserDataRepository? _userDataRepository;
    private IUserEmailAddressRepository? _userEmailAddressRepository;
    private IUserSettingRepository? _userSettingRepository;


    public IInternalUserRepository InternalUser => _internalUserRepository ??= new InternalUserRepository(_dbContext);

    public IUserRepository User => _userRepository ??= new UserRepository(_dbContext);

    public IUserDataRepository UserData => _userDataRepository ??= new UserDataRepository(_dbContext);

    public IUserEmailAddressRepository UserEmailAddress => _userEmailAddressRepository ??= new UserEmailAddressRepository(_dbContext);

    public IUserSettingRepository UserSetting => _userSettingRepository ??= new UserSettingRepository(_dbContext);
}
