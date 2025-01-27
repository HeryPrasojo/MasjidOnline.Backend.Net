using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface;

public interface IAdditionBusiness
{
    Task<AddResponse> AddAsync(UserSession _userSession, IUserData _userData, AddRequest addRequest);
}
