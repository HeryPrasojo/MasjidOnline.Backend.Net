using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IInfaqsData _infaqsData, GetOneRequest getOneRequest);
}
