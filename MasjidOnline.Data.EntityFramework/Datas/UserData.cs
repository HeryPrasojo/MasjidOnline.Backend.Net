using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Users;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Users;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class UserData(UserDataContext _userDataContext) : IUserData
{
    private IUserSettingRepository? _userSettingRepository;

    private IUserRepository? _userRepository;
    private IUserEmailAddressRepository? _userEmailAddressRepository;


    public IUserSettingRepository UserSetting => _userSettingRepository ??= new UserSettingRepository(_userDataContext);


    public IUserRepository User => _userRepository ??= new UserRepository(_userDataContext);

    public IUserEmailAddressRepository UserEmailAddress => _userEmailAddressRepository ??= new UserEmailAddressRepository(_userDataContext);


    public async Task SaveAsync()
    {
        await _userDataContext.SaveChangesAsync();
    }
}
