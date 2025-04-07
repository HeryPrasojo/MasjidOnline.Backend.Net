using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Captcha.Interface.Pass;

public interface IGetStatusBusiness
{
    Task<Response> GetAsync(IData _data, Session.Interface.Session session);
}
