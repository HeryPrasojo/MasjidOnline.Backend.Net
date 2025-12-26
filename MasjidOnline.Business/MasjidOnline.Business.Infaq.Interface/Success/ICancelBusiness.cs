using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface ICancelBusiness
{
    Task<Response> CancelAsync(Model.Session.Session session, IData _data, CancelRequest? cancelRequest);
}
