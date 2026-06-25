using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Donation.Donation;
using MasjidOnline.Business.Donation.Interface;
using MasjidOnline.Business.Donation.Interface.Donation;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Donation;

public class DonationDonationBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    Service.Interface.IService _service,
    IOptionsMonitor<BusinessOptions> _optionsMonitor
    ) : IDonationDonationBusiness
{
    public IAddBusiness Add { get; } = new AddBusiness(_authorizationBusiness, _service, _optionsMonitor);
    public IGetTableBusiness GetTable { get; } = new GetTableBusiness(_service);
    public IGetViewBusiness GetView { get; } = new GetViewBusiness(_service);
}



