using System.Threading.Tasks;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Donation.Interface.Donation;

public interface IGetRecommendationNoteBusiness
{
    Task<Response<string>> GetAsync(IData _data, Model.Session.Session session, GetRecommendationNoteRequest getRecommendationNoteRequest);
}
