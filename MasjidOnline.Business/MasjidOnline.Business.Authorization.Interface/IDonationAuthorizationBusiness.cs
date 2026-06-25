using MasjidOnline.Business.Authorization.Interface.Donation;

namespace MasjidOnline.Business.Authorization.Interface;

public interface IDonationAuthorizationBusiness
{
    IDonationAuthorization Donation { get; }
}


