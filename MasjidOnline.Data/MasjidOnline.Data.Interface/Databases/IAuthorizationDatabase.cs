using MasjidOnline.Data.Interface.Repository.Authorization;

namespace MasjidOnline.Data.Interface.Databases;

public interface IAuthorizationDatabase : IDatabase
{
    IAuthorizationSettingRepository AuthorizationSetting { get; }
    IInternalPermissionRepository InternalPermission { get; }
}
