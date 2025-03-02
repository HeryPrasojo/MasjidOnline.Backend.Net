using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.Users.Internal;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IAddBusiness
{
    Task<Response> AddAsync(ISessionBusiness _sessionBusiness, IUsersData _usersData, AddRequest addRequest);
}
