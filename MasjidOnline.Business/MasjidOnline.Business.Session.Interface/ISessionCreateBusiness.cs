using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session.Sessions;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Session.Interface;

public interface ISessionCreateBusiness
{
    Task<Response<string>> CreateAsync(IData _data, Model.Session.Session session, CreateRequest createRequest);
}
