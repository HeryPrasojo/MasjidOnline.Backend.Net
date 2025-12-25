using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetOneBusiness
{
    Task<Response<GetOneResponse>> GetAsync(Session.Interface.Model.Session session, IData _data, GetOneRequest? getOneRequest);
}
