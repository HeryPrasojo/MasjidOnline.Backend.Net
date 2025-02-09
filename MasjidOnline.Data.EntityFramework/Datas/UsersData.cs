using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Users;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Users;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class UsersData(UsersDataContext _userDataContext, IAuditData _auditData) : DataWithAudit(_userDataContext, _auditData), IUsersData
{
    private IUserSettingRepository? _userSettingRepository;

    private IPasswordCodeRepository? _passwordCodeRepository;
    private IUserRepository? _userRepository;
    private IUserEmailAddressRepository? _userEmailAddressRepository;


    public IUserSettingRepository UserSetting => _userSettingRepository ??= new UserSettingRepository(_userDataContext);


    public IPasswordCodeRepository PasswordCode => _passwordCodeRepository ??= new PasswordCodeRepository(_userDataContext);

    public IUserRepository User => _userRepository ??= new UserRepository(_userDataContext);

    public IUserEmailAddressRepository UserEmailAddress => _userEmailAddressRepository ??= new UserEmailAddressRepository(_userDataContext);
}
