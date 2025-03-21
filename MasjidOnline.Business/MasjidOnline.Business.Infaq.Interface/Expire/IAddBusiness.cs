using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IAddBusiness
{
    Task<Response> AddAsync(IAuthorizationBusiness _authorizationBusiness, IInfaqData _infaqData, ISessionBusiness _sessionBusiness, IUserData _userData, AddRequest addRequest);
}
