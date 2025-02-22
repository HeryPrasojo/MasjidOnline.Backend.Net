using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqGetBusiness
{
    Task<GetManyResponse<GetManyResponseRecord>> GetManyAsync(ISessionBusiness _sessionBusiness, IUsersData _usersData, IInfaqsData _infaqsData, GetManyRequest getManyRequest);
}
