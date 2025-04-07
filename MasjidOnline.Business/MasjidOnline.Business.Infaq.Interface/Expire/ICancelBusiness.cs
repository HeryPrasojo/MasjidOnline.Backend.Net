using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface ICancelBusiness
{
    Task<Response> CancelAsync(Session.Interface.Session _sessionBusiness, IData _data, CancelRequest? cancelRequest);
}
