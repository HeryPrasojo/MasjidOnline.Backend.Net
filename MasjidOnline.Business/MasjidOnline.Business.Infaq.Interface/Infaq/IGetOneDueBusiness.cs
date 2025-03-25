using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetOneDueBusiness
{
    Task<GetOneDueResponse> GetAsync(IInfaqDatabase _infaqDatabase, GetOneDueRequest? getOneDueRequest);
}
