using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Authorization;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Authorization;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class AuthorizationDatabase(AuthorizationDataContext _authorizationDataContext) : Database(_authorizationDataContext), IAuthorizationDatabase
{
    private IAuthorizationSettingRepository? _authorizationSettingRepository;
    private IInternalPermissionRepository? _internalPermissionRepository;


    public IInternalPermissionRepository InternalPermission => _internalPermissionRepository ??= new InternalPermissionRepository(_authorizationDataContext);

    public IAuthorizationSettingRepository AuthorizationSetting => _authorizationSettingRepository ??= new AuthorizationSettingRepository(_authorizationDataContext);
}