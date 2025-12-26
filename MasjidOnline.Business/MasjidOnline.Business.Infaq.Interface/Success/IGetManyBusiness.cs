using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IGetManyBusiness
{
    Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(IData _data, Model.Session.Session session, GetManyRequest? getManyRequest);
}
