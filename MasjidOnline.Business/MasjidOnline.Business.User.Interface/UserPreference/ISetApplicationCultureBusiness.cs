using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.UserPreference;

public interface ISetApplicationCultureBusiness
{
    Task<string> SetAsync(IData _data, Session.Interface.Model.Session session, string cultureName);
}
