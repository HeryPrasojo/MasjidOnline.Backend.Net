using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetOneDueBusiness
{
    Task<GetOneDueResponse> GetAsync(IInfaqDatabase _infaqDatabase, GetOneDueRequest? getOneDueRequest);
}
