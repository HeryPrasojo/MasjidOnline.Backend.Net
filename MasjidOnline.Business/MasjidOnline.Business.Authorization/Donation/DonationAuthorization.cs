using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Donation;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Donation;

internal class DonationAuthorization : AuthorizationBase, IDonationAuthorization
{
    public async Task AuthorizeRequestFailAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, donationStatusRequest: true);
    }
}


