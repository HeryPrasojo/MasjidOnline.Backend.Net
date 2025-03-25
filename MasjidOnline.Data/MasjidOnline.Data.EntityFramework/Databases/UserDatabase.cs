using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.User;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.User;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class UserDatabase(UserDataContext _userDataContext) : Data(_userDataContext), IUserDatabase
{
    private IInternalRepository? _internalRepository;
    private IPasswordCodeRepository? _passwordCodeRepository;
    private IPermissionRepository? _permissionRepository;
    private IUserRepository? _userRepository;
    private IUserEmailAddressRepository? _userEmailAddressRepository;
    private IUserSettingRepository? _userSettingRepository;


    public IInternalRepository Internal => _internalRepository ??= new InternalRepository(_userDataContext);

    public IPasswordCodeRepository PasswordCode => _passwordCodeRepository ??= new PasswordCodeRepository(_userDataContext);

    public IPermissionRepository Permission => _permissionRepository ??= new PermissionRepository(_userDataContext);

    public IUserRepository User => _userRepository ??= new UserRepository(_userDataContext);

    public IUserEmailAddressRepository UserEmailAddress => _userEmailAddressRepository ??= new UserEmailAddressRepository(_userDataContext);

    public IUserSettingRepository UserSetting => _userSettingRepository ??= new UserSettingRepository(_userDataContext);
}
