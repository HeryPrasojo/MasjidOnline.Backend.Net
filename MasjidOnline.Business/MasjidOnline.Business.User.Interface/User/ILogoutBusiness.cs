using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.User;

public interface ILogoutBusiness
{
    Task<Response> LogoutAsync(Session.Interface.Model.Session session, IData _data);
}
