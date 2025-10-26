using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface.Model.Sessions;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Session.Interface;

public interface ISessionSessionBusiness
{
    Task<Response<string>> CreateAsync(IData _data, Model.Session session, CreateRequest createRequest);
}
