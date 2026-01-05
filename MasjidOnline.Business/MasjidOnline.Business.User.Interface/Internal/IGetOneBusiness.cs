using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Business.Model.User.Internal;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IGetOneBusiness
{
    Task<Response<GetOneResponse>> GetAsync(Session session, IData _data, GetOneRequest? getOneRequest);
}
