using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IGetManyBusiness
{
    Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(IData _data, Session.Interface.Model.Session session, GetManyRequest? getManyRequest);
}
