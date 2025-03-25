using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IGetManyBusiness
{
    Task<GetManyResponse<GetManyResponseRecord>> GetAsync(IInfaqDatabase _infaqDatabase, GetManyRequest? getManyRequest);
}
