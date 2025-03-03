using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IGetManyBusiness
{
    Task<GetManyResponse<GetManyResponseRecord>> GetAsync(IUserData _userData, GetManyRequest getManyRequest);
}
