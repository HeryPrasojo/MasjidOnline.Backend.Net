using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface ICancelBusiness
{
    Task<Response> CancelAsync(Session.Interface.Model.Session session, IData _data, CancelRequest? cancelRequest);
}
