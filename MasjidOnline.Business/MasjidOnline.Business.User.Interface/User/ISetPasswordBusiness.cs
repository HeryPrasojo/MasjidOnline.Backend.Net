using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface.User;

public interface ISetPasswordBusiness
{
    Task<Response> SetAsync(IDataTransaction _dataTransaction, ISessionBusiness _sessionBusiness, ISessionData _sessionData, IUserData _userData, SetPasswordRequest? setPasswordRequest);
}
