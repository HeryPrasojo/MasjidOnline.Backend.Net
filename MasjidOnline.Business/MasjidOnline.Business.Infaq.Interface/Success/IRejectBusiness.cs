using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IRejectBusiness
{
    Task<Response> RejectAsync(ISessionBusiness _sessionBusiness, IUserData _userData, IInfaqData _infaqData, RejectRequest rejectRequest);
}
