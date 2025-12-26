using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface ICancelBusiness
{
    Task<Response> CancelAsync(Model.Session.Session session, IData _data, CancelRequest? cancelRequest);
}
