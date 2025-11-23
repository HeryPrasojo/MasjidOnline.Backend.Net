using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IGetManyBusiness
{
    Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(IData _data, Session.Interface.Model.Session session, GetManyRequest? getManyRequest);
}
