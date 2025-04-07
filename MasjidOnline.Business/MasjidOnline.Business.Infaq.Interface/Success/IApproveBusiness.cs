using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IApproveBusiness
{
    Task<Response> ApproveAsync(Session.Interface.Session _sessionBusiness, IData _data, ApproveRequest? approveRequest);
}
