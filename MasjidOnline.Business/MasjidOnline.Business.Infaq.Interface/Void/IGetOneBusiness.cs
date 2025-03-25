using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IData _data, GetOneRequest? getOneRequest);
}
