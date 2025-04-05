using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Captcha.Interface.Pass;

public interface IGetStatusBusiness
{
    Task<Response> GetAsync(IData _data, ISessionBusiness _sessionBusiness);
}
