using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IApproveBusiness
{
    Task<Response> ApproveAsync(Session.Interface.Session session, IData _data, ApproveRequest? approveRequest);
}
