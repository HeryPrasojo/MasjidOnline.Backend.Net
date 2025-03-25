using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface ICancelBusiness
{
    Task<Response> CancelAsync(ISessionBusiness _sessionBusiness, IUserDatabase _userDatabase, IInfaqDatabase _infaqDatabase, CancelRequest? cancelRequest);
}
