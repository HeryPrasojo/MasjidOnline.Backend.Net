using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface.User;

public interface ILoginBusiness
{
    Task<Response> LoginAsync(IUserData _userData, ISessionBusiness _sessionBusiness, LoginRequest? loginRequest);
}
