using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface;

public interface IPasswordSetBusiness
{
    Task<SetPasswordResponse> SetAsync(Session _session, ISessionsData _sessionsData, IUsersData _usersData, SetPasswordRequest setPasswordRequest);
}
