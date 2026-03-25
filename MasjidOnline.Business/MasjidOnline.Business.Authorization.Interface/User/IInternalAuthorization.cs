using System.Threading.Tasks;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Interface.User;

public interface IInternalAuthorization
{
    Task AuthorizeAddAync(Model.Session.Session session, IData _data);
    Task AuthorizeApproveAync(Model.Session.Session session, IData _data);
    Task AuthorizeGetAync(Session session, IData _data);
}
