using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Authorization.UserInternalPermission;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Interface.Authorization;

public interface IUserInternalPermissionAuthorization
{
    IGetViewBusiness GetView { get; }
    IUpdateBusiness Update { get; }

    Task AuthorizeGetAync(Session session, IData _data);
    Task AuthorizUpdateAync(Session session, IData _data);
}
