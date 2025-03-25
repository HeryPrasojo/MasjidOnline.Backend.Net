using MasjidOnline.Data.Interface.Repository.User;

namespace MasjidOnline.Data.Interface.Databases;

public interface IUserDatabase : IDatabase
{
    IPasswordCodeRepository PasswordCode { get; }
    IPermissionRepository Permission { get; }
    IUserRepository User { get; }
    IUserEmailAddressRepository UserEmailAddress { get; }
    IUserSettingRepository UserSetting { get; }
    IInternalRepository Internal { get; }
}
