using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface;

public interface IInitializerBusiness
{
    Task InitializeAsync(ISessionBusiness _sessionBusiness, IUsersData _usersData);
}
