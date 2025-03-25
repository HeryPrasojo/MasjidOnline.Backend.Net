using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IGetOneNewBusiness
{
    Task<GetOneNewResponse> GetAsync(IInfaqDatabase _infaqDatabase, GetOneNewRequest? getOneRequest);
}
