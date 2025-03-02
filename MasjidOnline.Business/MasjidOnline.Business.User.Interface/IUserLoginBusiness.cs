using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.Users;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface;

public interface IUserLoginBusiness
{
    Task<Response> LoginAsync(IUsersData _usersData, ISessionBusiness _sessionBusiness, LoginRequest loginRequest);
}
