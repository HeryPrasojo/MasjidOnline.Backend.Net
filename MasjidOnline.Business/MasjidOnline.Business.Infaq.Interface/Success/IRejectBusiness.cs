using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IRejectBusiness
{
    Task<Response> RejectAsync(Session.Interface.Session session, IData _data, RejectRequest? rejectRequest);
}
