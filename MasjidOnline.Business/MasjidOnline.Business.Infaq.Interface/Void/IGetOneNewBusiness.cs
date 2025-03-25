using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IGetOneNewBusiness
{
    Task<GetOneNewResponse> GetAsync(IData _data, GetOneNewRequest? getOneNewRequest);
}
