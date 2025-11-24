using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.User;

public interface ILoginEmailBusiness
{
    Task<Response<LoginResponse>> LoginAsync(IData _data, Session.Interface.Model.Session session, LoginRequest? loginRequest);
}
