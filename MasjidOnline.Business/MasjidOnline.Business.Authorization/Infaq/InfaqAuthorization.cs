using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Infaq;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Infaq;

internal class InfaqAuthorization : AuthorizationBase, IInfaqAuthorization
{
    public async Task AuthorizeOnBehalfAddAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAsync(session, _data, infaqOnBehalfAdd: true);
    }
}
