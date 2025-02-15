using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Users;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Users;

public class UserSettingRepository(UsersDataContext _userDataContext) : IUserSettingRepository
{
    private readonly DbSet<UserSetting> _dbSet = _userDataContext.Set<UserSetting>();

    public async Task AddAsync(UserSetting userSetting)
    {
        await _dbSet.AddAsync(userSetting);
    }
}
