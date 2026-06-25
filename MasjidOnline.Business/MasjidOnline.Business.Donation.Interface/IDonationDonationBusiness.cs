using MasjidOnline.Business.Donation.Interface.Donation;

namespace MasjidOnline.Business.Donation.Interface;

public interface IDonationDonationBusiness
{
    IAddBusiness Add { get; }
    IGetTableBusiness GetTable { get; }
    IGetViewBusiness GetView { get; }
}



