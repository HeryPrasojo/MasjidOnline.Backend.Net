using MasjidOnline.Business.Infaq.Interface.Model.Expired;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Expired;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IInfaqsData _infaqsData, GetOneRequest getOneRequest);
}
