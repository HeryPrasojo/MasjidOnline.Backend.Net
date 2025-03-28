using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetManyBusiness
{
    Task<GetManyResponse<GetManyResponseRecord>> GetAsync(IData _data, GetManyRequest? getManyRequest);
}
