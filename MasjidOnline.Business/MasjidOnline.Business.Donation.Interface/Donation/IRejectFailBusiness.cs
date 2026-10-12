using System.Threading.Tasks;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Donation.Interface.Donation;

public interface IRejectFailBusiness
{
    Task<Response> RejectAsync(Session session, IData _data, RejectFailRequest rejectFailRequest);
}
