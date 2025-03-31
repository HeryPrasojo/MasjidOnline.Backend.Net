using MasjidOnline.Data.Interface.Repository.User;

namespace MasjidOnline.Data.Interface.Databases;

public interface IUserDatabase : IDatabase
{
    IInternalRepository Internal { get; }
    IPasswordCodeRepository PasswordCode { get; }
    IUserRepository User { get; }
    IUserEmailAddressRepository UserEmailAddress { get; }
    IUserSettingRepository UserSetting { get; }
}
