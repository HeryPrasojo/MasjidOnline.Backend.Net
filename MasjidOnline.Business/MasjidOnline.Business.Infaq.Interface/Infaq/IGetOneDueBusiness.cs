using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetOneDueBusiness
{
    Task<GetOneDueResponse> GetAsync(IInfaqData _infaqData, GetOneDueRequest getOneDueRequest);
}
