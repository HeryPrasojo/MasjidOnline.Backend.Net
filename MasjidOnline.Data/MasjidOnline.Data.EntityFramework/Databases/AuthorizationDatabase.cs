using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Authorization;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Authorization;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class AuthorizationDatabase(AuthorizationDataContext _authorizationDataContext) : Database(_authorizationDataContext), IAuthorizationDatabase
{
    private IAuthorizationSettingRepository? _authorizationSettingRepository;
    private IUserInternalPermissionRepository? _userInternalPermissionRepository;


    public IUserInternalPermissionRepository UserInternalPermission => _userInternalPermissionRepository ??= new UserInternalPermissionRepository(_authorizationDataContext);

    public IAuthorizationSettingRepository AuthorizationSetting => _authorizationSettingRepository ??= new AuthorizationSettingRepository(_authorizationDataContext);
}