using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IGetManyNewBusiness
{
    Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(IData _data, GetManyNewRequest? getManyNewRequest);
}
