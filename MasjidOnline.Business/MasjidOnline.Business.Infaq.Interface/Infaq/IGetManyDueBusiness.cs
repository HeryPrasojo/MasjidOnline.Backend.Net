using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetManyDueBusiness
{
    Task<GetManyResponse<GetManyDueResponseRecord>> GetAsync(IInfaqDatabase _infaqDatabase, GetManyDueRequest? getManyDueRequest);
}
