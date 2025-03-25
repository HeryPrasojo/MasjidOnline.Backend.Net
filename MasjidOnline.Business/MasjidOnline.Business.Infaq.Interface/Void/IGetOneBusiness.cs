using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IInfaqData _infaqData, GetOneRequest? getOneRequest);
}
