using System.Threading.Tasks;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IGetOneNewBusiness
{
    Task<GetOneNewResponse> GetAsync(IData _data, GetOneNewRequest? getOneNewRequest);
}
