using MasjidOnline.Business.Infaq.Interface.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface;

public interface ITabularBusiness
{
    Task<IEnumerable<TabularQueryResponse>> QueryAsync(ISessionBusiness _sessionBusiness, IUsersData _usersData, IInfaqsData _infaqsData, TabularQueryRequest queryRequest);
}
