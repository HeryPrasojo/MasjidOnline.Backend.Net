using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IRejectBusiness
{
    Task<Response> RejectAsync(ISessionBusiness _sessionBusiness, IData _data, RejectRequest? rejectRequest);
}
