using MasjidOnline.Data.Interface.Repository.User;

namespace MasjidOnline.Data.Interface.Datas;

public interface IUserData : IData
{
    IPasswordCodeRepository PasswordCode { get; }
    IPermissionRepository Permission { get; }
    IUserRepository User { get; }
    IUserEmailAddressRepository UserEmailAddress { get; }
    IUserSettingRepository UserSetting { get; }
    IInternalRepository Internal { get; }
}
