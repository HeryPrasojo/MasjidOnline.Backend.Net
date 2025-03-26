using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.User;

public interface ISetPasswordBusiness
{
    Task<Response> SetAsync(ISessionBusiness _sessionBusiness, IData _data, SetPasswordRequest? setPasswordRequest);
}
