using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.User;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class UserPreferenceRepository(UserDataContext _userDataContext) : IUserPreferenceRepository
{
}
