using MasjidOnline.Api.Model.Donation;
using MasjidOnline.Business.Donation.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Donation;

public class AnonymDonateBusiness(IDataAccess dataAccess) : IAnonymDonateBusiness
{
    public void Donate(string sessionId, DonateRequest donateRequest)
    {
        if (sessionId == default)
        {

        }
    }
}
