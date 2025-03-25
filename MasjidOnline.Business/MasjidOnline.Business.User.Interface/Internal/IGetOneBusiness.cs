using System.Threading.Tasks;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IUserDatabase _userDatabase, GetOneRequest? getOneRequest);
}
