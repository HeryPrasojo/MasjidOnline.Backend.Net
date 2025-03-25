using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IGetManyNewBusiness
{
    Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(IInfaqData _infaqData, GetManyNewRequest? getManyNewRequest);
}
