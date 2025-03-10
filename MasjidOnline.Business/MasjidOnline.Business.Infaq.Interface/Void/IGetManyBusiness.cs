using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IGetManyBusiness
{
    Task<GetManyResponse<GetManyResponseRecord>> GetAsync(IInfaqData _infaqData, GetManyRequest getManyRequest);
}
