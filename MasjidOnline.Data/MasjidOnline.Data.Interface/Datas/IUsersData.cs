using MasjidOnline.Data.Interface.Repository.Users;

namespace MasjidOnline.Data.Interface.Datas;

public interface IUsersData : IData
{
    IPasswordCodeRepository PasswordCode { get; }
    IPermissionRepository Permission { get; }
    IUserRepository User { get; }
    IUserEmailAddressRepository UserEmailAddress { get; }
    IUserSettingRepository UserSetting { get; }
}
