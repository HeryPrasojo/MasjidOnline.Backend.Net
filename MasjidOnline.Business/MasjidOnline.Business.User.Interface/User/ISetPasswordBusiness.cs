using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.User;

public interface ISetPasswordBusiness
{
    Task<Response> SetAsync(Session.Interface.Session _sessionBusiness, IData _data, SetPasswordRequest? setPasswordRequest);
}
