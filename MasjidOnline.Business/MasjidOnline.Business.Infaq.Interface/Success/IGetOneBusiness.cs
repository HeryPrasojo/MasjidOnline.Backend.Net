using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IInfaqDatabase _infaqDatabase, GetOneRequest? getOneRequest);
}
