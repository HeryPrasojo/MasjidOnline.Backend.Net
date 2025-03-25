using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IRejectBusiness
{
    Task<Response> RejectAsync(ISessionBusiness _sessionBusiness, IUserDatabase _userDatabase, IInfaqDatabase _infaqDatabase, RejectRequest? rejectRequest);
}
