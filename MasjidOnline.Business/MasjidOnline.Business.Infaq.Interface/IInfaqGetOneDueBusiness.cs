using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqGetOneDueBusiness
{
    Task<GetOneDueResponse> GetAsync(IInfaqsData _infaqsData, GetOneDueRequest getOneDueRequest);
}
