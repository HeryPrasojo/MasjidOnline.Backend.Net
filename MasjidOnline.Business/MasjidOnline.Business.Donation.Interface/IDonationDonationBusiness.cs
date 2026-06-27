using MasjidOnline.Business.Donation.Interface.Donation;

namespace MasjidOnline.Business.Donation.Interface;

public interface IDonationDonationBusiness
{
    IAddBusiness Add { get; }
    IGetRecommendationNoteBusiness GetRecommendationNote { get; }
    IGetTableBusiness GetTable { get; }
    IGetViewBusiness GetView { get; }
}



