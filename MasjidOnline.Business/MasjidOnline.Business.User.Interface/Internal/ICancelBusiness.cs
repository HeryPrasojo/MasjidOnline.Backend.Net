using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface ICancelBusiness
{
    Task<Response> CancelAsync(ISessionBusiness _sessionBusiness, IUserDatabase _userDatabase, CancelRequest? cancelRequest);
}
