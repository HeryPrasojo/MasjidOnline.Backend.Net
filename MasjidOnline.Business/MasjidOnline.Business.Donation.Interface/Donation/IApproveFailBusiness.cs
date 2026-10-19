using System.Threading.Tasks;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Donation.Interface.Donation;

public interface IApproveFailBusiness
{
    Task<Response> ApproveAsync(Session session, IData _data, ApproveFailRequest approveFailRequest);
}
