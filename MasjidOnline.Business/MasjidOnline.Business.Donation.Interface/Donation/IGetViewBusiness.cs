using System.Threading.Tasks;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Donation.Interface.Donation;

public interface IGetViewBusiness
{
    Task<Response<ViewResponse>> GetAsync(Model.Session.Session session, IData _data, ViewRequest? viewRequest);
}


