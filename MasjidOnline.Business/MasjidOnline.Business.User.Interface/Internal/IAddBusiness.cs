using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IAddBusiness
{
    Task<Response> AddAsync(ISessionBusiness _sessionBusiness, IUserDatabase _userDatabase, AddRequest? addRequest);
}
