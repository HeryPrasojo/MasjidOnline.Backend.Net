using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Void;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IRejectBusiness
{
    Task<Response> RejectAsync(Model.Session.Session session, IData _data, RejectRequest? rejectRequest);
}
