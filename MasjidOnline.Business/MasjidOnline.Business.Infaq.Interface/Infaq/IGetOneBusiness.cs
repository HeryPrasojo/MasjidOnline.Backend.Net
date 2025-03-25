using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IInfaqDatabase _infaqDatabase, GetOneRequest? getOneRequest);
}
