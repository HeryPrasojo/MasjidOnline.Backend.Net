using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IApproveBusiness
{
    Task<Response> ApproveAsync(Model.Session.Session session, IData _data, ApproveRequest? approveRequest);
}
