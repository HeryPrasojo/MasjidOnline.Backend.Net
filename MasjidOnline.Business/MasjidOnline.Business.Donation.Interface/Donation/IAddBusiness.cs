using System.Threading.Tasks;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Donation.Interface.Donation;

public interface IAddBusiness
{
    Task<Response> AddAsync(IData _data, Model.Session.Session session, AddRequest? addRequest);
}


