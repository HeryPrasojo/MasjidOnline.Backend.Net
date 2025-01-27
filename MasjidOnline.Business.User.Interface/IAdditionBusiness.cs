using System.Threading.Tasks;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface;

public interface IAdditionBusiness
{
    Task<AddResponse> AddAsync(IUserData _userData, AddRequest addRequest);
}
