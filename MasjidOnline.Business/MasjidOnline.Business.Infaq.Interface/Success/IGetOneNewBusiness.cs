using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IGetOneNewBusiness
{
    Task<GetOneNewResponse> GetAsync(IInfaqDatabase _infaqDatabase, GetOneNewRequest? getOneNewRequest);
}
