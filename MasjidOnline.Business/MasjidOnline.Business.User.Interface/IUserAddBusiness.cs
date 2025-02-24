using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface;

public interface IUserAddBusiness
{
    Task<Response> AddByInternalAsync(ISessionBusiness _sessionBusiness, IUsersData _usersData, AddByInternalRequest addByInternalRequest);
}
