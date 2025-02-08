using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface;

public interface IPasswordSetBusiness
{
    Task<Response> SetAsync(ISessionBusiness _sessionBusiness, IUsersData _usersData, SetPasswordRequest setPasswordRequest);
}
