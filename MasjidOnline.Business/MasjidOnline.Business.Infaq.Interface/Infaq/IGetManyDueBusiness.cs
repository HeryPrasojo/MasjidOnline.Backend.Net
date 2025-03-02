using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetManyDueBusiness
{
    Task<GetManyResponse<GetManyDueResponseRecord>> GetAsync(IInfaqData _infaqData, GetManyDueRequest getManyDueRequest);
}
