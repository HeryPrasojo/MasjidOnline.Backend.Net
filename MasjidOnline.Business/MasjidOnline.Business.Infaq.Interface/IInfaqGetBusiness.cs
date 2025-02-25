using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqGetBusiness
{
    Task<GetManyResponse<GetManyResponseRecord>> GetManyAsync(IInfaqsData _infaqsData, GetManyRequest getManyRequest);
    Task<GetOneResponse> GetOneAsync(IInfaqsData _infaqsData, GetOneRequest getOneRequest);
}
