using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IGetManyNewBusiness
{
    Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(IUserDatabase _userDatabase, GetManyNewRequest? getManyNewRequest);
}
