using MasjidOnline.Business.Infaq.Interface.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqGetBusiness
{
    Task<IEnumerable<GetManyResponse>> GetManyAsync(ISessionBusiness _sessionBusiness, IUsersData _usersData, IInfaqsData _infaqsData, GetManyRequest getManyRequest);
}
