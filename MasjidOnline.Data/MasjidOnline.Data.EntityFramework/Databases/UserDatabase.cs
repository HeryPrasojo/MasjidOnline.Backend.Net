using MasjidOnline.Data.EntityFramework.Repository.User;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class UserDatabase(DbContext _dbContext) : Database(_dbContext), IUserDatabase
{
    private IInternalUserRepository? _internalUserRepository;
    private IPasswordCodeRepository? _passwordCodeRepository;
    private IUserRepository? _userRepository;
    private IUserPreferenceRepository? _userPreferenceRepository;
    private IUserEmailAddressRepository? _userEmailAddressRepository;
    private IUserSettingRepository? _userSettingRepository;


    public IInternalUserRepository InternalUser => _internalUserRepository ??= new InternalUserRepository(_dbContext);

    public IPasswordCodeRepository PasswordCode => _passwordCodeRepository ??= new PasswordCodeRepository(_dbContext);

    public IUserRepository User => _userRepository ??= new UserRepository(_dbContext);

    public IUserPreferenceRepository UserPreference => _userPreferenceRepository ??= new UserPreferenceRepository(_dbContext);

    public IUserEmailAddressRepository UserEmailAddress => _userEmailAddressRepository ??= new UserEmailAddressRepository(_dbContext);

    public IUserSettingRepository UserSetting => _userSettingRepository ??= new UserSettingRepository(_dbContext);
}
