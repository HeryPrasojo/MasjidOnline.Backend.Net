using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IGetOneNewBusiness
{
    Task<GetOneNewResponse> GetAsync(IData _data, GetOneNewRequest? getOneNewRequest);
}
