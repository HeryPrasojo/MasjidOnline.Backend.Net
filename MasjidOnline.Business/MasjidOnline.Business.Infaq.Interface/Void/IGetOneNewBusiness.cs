using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IGetOneNewBusiness
{
    Task<GetOneNewResponse> GetAsync(IInfaqDatabase _infaqDatabase, GetOneNewRequest? getOneNewRequest);
}
