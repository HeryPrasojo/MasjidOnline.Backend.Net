using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IGetManyBusiness
{
    Task<GetManyResponse<GetManyResponseRecord>> GetAsync(Session.Interface.Session _sessionBusiness, IData _data, GetManyRequest? getManyRequest);
}
