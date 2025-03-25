using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IApproveBusiness
{
    Task<Response> ApproveAsync(ISessionBusiness _sessionBusiness, IUserDatabase _userDatabase, IInfaqDatabase _infaqDatabase, ApproveRequest? approveRequest);
}
