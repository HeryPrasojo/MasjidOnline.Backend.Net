using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Payment.Interface.Model.Manual;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Payment.Interface.Manual;

public interface IGetRecommendationNoteBusiness
{
    Task<Response<string>> GetAsync(IData _data, Session.Interface.Model.Session session, GetRecommendationNoteRequest getRecommendationNoteRequest);
}
