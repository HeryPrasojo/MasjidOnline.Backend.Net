using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IGetOneNewBusiness
{
    Task<GetOneNewResponse> GetAsync(IData _data, GetOneNewRequest? getOneRequest);
}
