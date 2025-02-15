using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Users;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Users;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class UsersData(
    UsersDataContext _userDataContext,
    IAuditData _auditData,
    IDataTransaction _dataTransaction) : DataWithAudit(_userDataContext, _auditData, _dataTransaction), IUsersData
{
    private IUserSettingRepository? _userSettingRepository;

    private IPasswordCodeRepository? _passwordCodeRepository;
    private IPermissionRepository? _permissionRepository;
    private IUserRepository? _userRepository;
    private IUserEmailAddressRepository? _userEmailAddressRepository;


    public IUserSettingRepository UserSetting => _userSettingRepository ??= new UserSettingRepository(_userDataContext);


    public IPasswordCodeRepository PasswordCode => _passwordCodeRepository ??= new PasswordCodeRepository(_userDataContext);

    public IPermissionRepository Permission => _permissionRepository ??= new PermissionRepository(_userDataContext);

    public IUserRepository User => _userRepository ??= new UserRepository(_userDataContext);

    public IUserEmailAddressRepository UserEmailAddress => _userEmailAddressRepository ??= new UserEmailAddressRepository(_userDataContext);
}
