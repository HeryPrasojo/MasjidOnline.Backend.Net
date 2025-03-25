using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IGetManyNewBusiness
{
    Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(IData _data, GetManyNewRequest? getManyNewRequest);
}
