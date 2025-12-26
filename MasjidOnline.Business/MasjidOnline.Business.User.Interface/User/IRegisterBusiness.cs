using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.User;

public interface IRegisterBusiness
{
    Task<Response> RegisterAsync(IData _data, Business.Model.Session.Session session, RegisterRequest? registerRequest);
}
