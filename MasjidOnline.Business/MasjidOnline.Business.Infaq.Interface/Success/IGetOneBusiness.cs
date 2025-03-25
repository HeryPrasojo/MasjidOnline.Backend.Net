using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IData _data, GetOneRequest? getOneRequest);
}
