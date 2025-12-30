using MasjidOnline.Data.Interface.Repository.User;

namespace MasjidOnline.Data.Interface.Databases;

public interface IUserDatabase : IDatabase
{
    IInternalUserRepository InternalUser { get; }
    IUserRepository User { get; }
    IUserEmailRepository UserEmail { get; }
    IUserSettingRepository UserSetting { get; }
    IUserDataRepository UserData { get; }
}
