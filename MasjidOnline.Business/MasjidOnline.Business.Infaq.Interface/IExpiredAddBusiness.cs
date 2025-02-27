using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IExpiredAddBusiness
{
    Task<Response> AddAsync(IAuthorizationBusiness _authorizationBusiness, IInfaqsData _infaqsData, ISessionBusiness _sessionBusiness, IUsersData _usersData, ExpiredAddRequest expiredAddRequest);
}
