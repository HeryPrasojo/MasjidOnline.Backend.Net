using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Interface.Infaq;

public interface IExpireAuthorization
{
    Task AuthorizeAddAync(Session.Interface.Model.Session session, IData _data);
    Task AuthorizeApproveAync(Session.Interface.Model.Session session, IData _data);
    Task AuthorizeCancelAync(Session.Interface.Model.Session session, IData _data);
}
