using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

// todo low change *DataContext to DbContext
public class UserSettingRepository(UserDataContext _userDataContext) : IUserSettingRepository
{
    private readonly DbSet<UserSetting> _dbSet = _userDataContext.Set<UserSetting>();

    public async Task AddAsync(UserSetting userSetting)
    {
        await _dbSet.AddAsync(userSetting);
    }
}
