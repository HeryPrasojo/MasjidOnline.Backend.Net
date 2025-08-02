using MasjidOnline.Data.EntityFramework.Repository.Authorization;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class AuthorizationDatabase(DbContext _dbContext) : Database(_dbContext), IAuthorizationDatabase
{
    private IAuthorizationSettingRepository? _authorizationSettingRepository;
    private IUserInternalPermissionRepository? _userInternalPermissionRepository;


    public IUserInternalPermissionRepository UserInternalPermission => _userInternalPermissionRepository ??= new UserInternalPermissionRepository(_dbContext);

    public IAuthorizationSettingRepository AuthorizationSetting => _authorizationSettingRepository ??= new AuthorizationSettingRepository(_dbContext);
}