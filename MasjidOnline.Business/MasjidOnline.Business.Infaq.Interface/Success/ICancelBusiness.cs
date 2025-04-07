using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface ICancelBusiness
{
    Task<Response> CancelAsync(Session.Interface.Session _sessionBusiness, IData _data, CancelRequest? cancelRequest);
}
