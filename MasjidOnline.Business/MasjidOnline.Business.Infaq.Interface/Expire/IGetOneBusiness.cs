using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IInfaqData _infaqData, GetOneRequest? getOneRequest);
}
