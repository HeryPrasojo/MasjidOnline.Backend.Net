using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Payment.Interface.Manual;

public interface IGetRecommendationNoteBusiness
{
    Task<Response<string>> Get(IData _data, Session.Interface.Model.Session session);
}
