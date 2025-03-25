using System.Threading.Tasks;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IGetOneNewBusiness
{
    Task<GetOneNewResponse> GetAsync(IUserDatabase _userDatabase, GetOneNewRequest? getOneNewRequest);
}
