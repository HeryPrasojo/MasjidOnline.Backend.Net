using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IRejectBusiness
{
    Task<Response> RejectAsync(Session.Interface.Model.Session session, IData _data, RejectRequest? rejectRequest);
}
