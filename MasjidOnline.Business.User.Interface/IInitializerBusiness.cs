using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface;

public interface IInitializerBusiness
{
    Task InitializeAsync(Session _userSession, IUserData _userData);
}
