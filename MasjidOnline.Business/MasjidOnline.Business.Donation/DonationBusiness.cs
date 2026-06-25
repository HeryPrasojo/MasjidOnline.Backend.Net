using MasjidOnline.Business.Donation.Interface;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Donation;

public class DonationBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Service.Interface.IService _service
    ) : IDonationBusiness
{
    public IDonationDonationBusiness Donation { get; } = new DonationDonationBusiness(_authorizationBusiness, _service, _optionsMonitor);
}



