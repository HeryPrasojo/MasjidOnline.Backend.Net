using MasjidOnline.Business.Authorization.Donation;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.Donation;

namespace MasjidOnline.Business.Authorization;

internal class DonationAuthorizationBusiness : IDonationAuthorizationBusiness
{
    public IDonationAuthorization Donation { get; } = new DonationAuthorization();
}


