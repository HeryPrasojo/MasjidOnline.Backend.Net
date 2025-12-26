using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.User;

public interface ILoginBusiness
{
    Task<Response<LoginResponse>> LoginAsync(IData _data, Business.Model.Session.Session session, LoginRequest? loginRequest);
}
