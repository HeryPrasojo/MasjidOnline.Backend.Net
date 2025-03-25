using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetOneDueBusiness
{
    Task<GetOneDueResponse> GetAsync(IData _data, GetOneDueRequest? getOneDueRequest);
}
