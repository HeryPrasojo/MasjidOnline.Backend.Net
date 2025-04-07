using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IRejectBusiness
{
    Task<Response> RejectAsync(Session.Interface.Session _sessionBusiness, IData _data, RejectRequest? rejectRequest);
}
