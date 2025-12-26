using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IGetManyBusiness
{
    Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(IData _data, Model.Session.Session session, GetManyRequest? getManyRequest);
}
