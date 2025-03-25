using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IAddBusiness
{
    Task<Response> AddAsync(IAuthorizationBusiness _authorizationBusiness, IInfaqDatabase _infaqDatabase, ISessionBusiness _sessionBusiness, IUserDatabase _userDatabase, AddRequest? addRequest);
}
