using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface ICancelBusiness
{
    Task<Response> CancelAsync(ISessionBusiness _sessionBusiness, IUserData _userData, IInfaqData _infaqData, CancelRequest cancelRequest);
}
