using System.Threading.Tasks;
using MasjidOnline.Business.Payment.Interface.Model.Manual;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Payment.Interface.Manual;

public interface IGetRecommendationNoteBusiness
{
    Task<GetRecommendationNoteResponse> Get(IData _data, Session.Interface.Model.Session session);
}
