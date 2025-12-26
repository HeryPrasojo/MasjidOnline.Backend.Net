using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.User;

public interface ILogoutBusiness
{
    Task<Response> LogoutAsync(Business.Model.Session.Session session, IData _data);
}
