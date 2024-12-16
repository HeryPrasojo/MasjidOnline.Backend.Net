using MasjidOnline.Api.Model.Donation;
using MasjidOnline.Business.Donation.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Donation;

public class DonateBusiness(IDataAccess dataAccess) : IDonateBusiness
{
    public void Donate(DonateRequest donateRequest)
    {

    }
}
