using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Business.Model.User.Internal;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IGetViewBusiness
{
    Task<Response<ViewResponse>> GetAsync(Session session, IData _data, ViewRequest? viewRequest);
}
