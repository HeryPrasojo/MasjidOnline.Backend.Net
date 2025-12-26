using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IRejectBusiness
{
    Task<Response> RejectAsync(Model.Session.Session session, IData _data, RejectRequest? rejectRequest);
}
