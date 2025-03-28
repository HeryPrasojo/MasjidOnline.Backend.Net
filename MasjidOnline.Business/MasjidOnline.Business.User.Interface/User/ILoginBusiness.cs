using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.User;

public interface ILoginBusiness
{
    Task<Response> LoginAsync(IData _data, ISessionBusiness _sessionBusiness, LoginRequest? loginRequest);
}
