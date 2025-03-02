using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.Users;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface;

public interface IUserSetPasswordBusiness
{
    Task<Response> SetAsync(IDataTransaction _dataTransaction, ISessionBusiness _sessionBusiness, ISessionsData _sessionsData, IUsersData _usersData, SetPasswordRequest setPasswordRequest);
}
