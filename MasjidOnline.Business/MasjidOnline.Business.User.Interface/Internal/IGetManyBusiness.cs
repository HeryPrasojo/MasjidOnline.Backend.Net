using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.Internal;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IGetManyBusiness
{
    Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(Business.Model.Session.Session session, IData _data, GetManyRequest? getManyRequest);
}
