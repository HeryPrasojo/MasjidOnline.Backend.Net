using System.Threading.Tasks;
using MasjidOnline.Business.Model.Payment.Manual;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Payment.Interface.Manual;

public interface IGetRecommendationNoteBusiness
{
    Task<Response<string>> GetAsync(IData _data, Model.Session.Session session, GetRecommendationNoteRequest getRecommendationNoteRequest);
}
